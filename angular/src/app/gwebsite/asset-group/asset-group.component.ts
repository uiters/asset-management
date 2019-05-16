import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { CreateOrEditAssetGroupModalComponent } from './create-or-edit-asset-group-modal.component';
import { WebApiServiceProxy, IFilter } from '@shared/service-proxies/webapi.service';
import { AssetTypeDto } from '../asset-type/dto/asset-type.dto';
import { AssetGroupDto } from './dto/asset-group.dto';
import { finalize } from 'rxjs/operators';
import { GroupAssetServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: './asset-group.component.html',
  animations: [appModuleAnimation()]
})
export class AssetGroupComponent extends AppComponentBase implements AfterViewInit, OnInit {

    @ViewChild('textsTable') textsTable: ElementRef;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditAssetGroupModalComponent;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    filterText: string;

    constructor(
        injector: Injector,
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _apiService: WebApiServiceProxy,
        private _apiAssetGroupService: GroupAssetServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {
    }

    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }

    getAssetGroups(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._apiService.get('api/GroupAsset/GetAssetsByFilter',
            [{ fieldName: 'Name', value: this.filterText }],
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(async result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            await this.setAssetType(result.items);
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteAssetGroup(id: number): void {
        this._apiService.delete("api/GroupAsset/DeleteGroupAsset?", id)
            .subscribe(() => {
                this.notify.info(this.l('DeletedSuccessfully'));
                this.reloadPage();
            });
        // this._apiAssetGroupService.deleteGroupAsset(id).subscribe(() => this.reloadPage());
    }

    setAssetType(assetGroups: AssetGroupDto[]): void {
        this._apiService.get('api/AssetType/GetAssetTypes'
        ).subscribe(result => {
            assetGroups.map((assetGroup, index) => {
                assetGroup.index = index + 1;
                for (let assetType of result.items) {
                    if (assetType.id.toString() === assetGroup.assetTypeCode) {
                        return assetGroup.assetType = { ...assetType };
                    }
                }
            });
        });
    }

    init(): void {
        this._activatedRoute.params.subscribe((params: Params) => {
            this.filterText = params['filterText'] || '';
            this.reloadPage();
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        this._router.navigate(['app/gwebsite/asset-group', {
            filterText: this.filterText
        }]);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

    refreshValueFromModal(): void {
        if (this.createOrEditModal.assetGroup.id) {
            for (let i = 0; i < this.primengTableHelper.records.length; i++) {
                if (this.primengTableHelper.records[i].id === this.createOrEditModal.assetGroup.id) {
                    this.primengTableHelper.records[i] = this.createOrEditModal.assetGroup;
                    return;
                }
            }
        } else { this.reloadPage(); }
    }

    createAssetGroup() {
        this.createOrEditModal.show();
    }
}
