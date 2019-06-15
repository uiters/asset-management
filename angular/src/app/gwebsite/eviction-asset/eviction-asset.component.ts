import {
    AfterViewInit,
    Component,
    ElementRef,
    Injector,
    OnInit,
    ViewChild
} from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { CreateOrEditEvictionAssetModalComponent } from './create-or-edit-eviction-asset-modal.component';
import { ViewEvictionAssetModalComponent } from './view-eviction-asset-modal.component';
import {
    WebApiServiceProxy,
    IFilter
} from '@shared/service-proxies/webapi.service';
import * as moment from 'moment';
@Component({
    templateUrl: './eviction-asset.component.html',
    animations: [appModuleAnimation()]
})
export class EvictionAssetComponent extends AppComponentBase
    implements AfterViewInit, OnInit {
    @ViewChild('textsTable') textsTable: ElementRef;
    @ViewChild('createOrEditModal')
    createOrEditModal: CreateOrEditEvictionAssetModalComponent;
    @ViewChild('viewModal') viewModal: ViewEvictionAssetModalComponent;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    filterText: string;

    constructor(
        injector: Injector,
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _apiService: WebApiServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {}

    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }

    formatDate(str: any): any {
        return moment(str).format('DD/MM/YYYY');
    }

    getEvictionAssets(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._apiService
            .get(
                'api/EvictionAsset/GetEvictionAssetsByFilter',
                [{ fieldName: 'Name', value: this.filterText }],
                this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getMaxResultCount(
                    this.paginator,
                    event
                ),
                this.primengTableHelper.getSkipCount(this.paginator, event)
            )
            .subscribe(async result => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                const tranformList = result.items.map((item, index) => ({
                    ...item,
                    index: index + 1
                }));
                this.primengTableHelper.records = tranformList;
                this.primengTableHelper.hideLoadingIndicator();
            });
    }

    deleteEvictionAsset(id: number): void {
        this._apiService
            .delete('api/EvictionAsset/DeleteEvictionAsset?', id)
            .subscribe(() => {
                this.notify.info(this.l('DeletedSuccessfully'));
                this.reloadPage();
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
        this._router.navigate([
            'app/gwebsite/eviction-asset',
            {
                filterText: this.filterText
            }
        ]);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

    refreshValueFromModal(): void {
        if (this.createOrEditModal.evictionAsset.id) {
            for (let i = 0; i < this.primengTableHelper.records.length; i++) {
                if (
                    this.primengTableHelper.records[i].id ===
                    this.createOrEditModal.evictionAsset.id
                ) {
                    this.primengTableHelper.records[
                        i
                    ] = this.createOrEditModal.evictionAsset;
                    this.primengTableHelper.records[i].index = i + 1;
                    return;
                }
            }
        } else {
            this.reloadPage();
        }
    }

    createEvictionAsset() {
        this.createOrEditModal.show();
    }
}
