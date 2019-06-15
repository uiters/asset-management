import { Component, OnInit, ViewChild, AfterViewInit, Injector } from '@angular/core';
import { Table } from 'primeng/table';
import { Paginator, LazyLoadEvent } from 'primeng/primeng';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivatedRoute, Params } from '@angular/router';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { CreateOrEditExportAssetModelComponent } from '../create-or-edit-export-asset-model/create-or-edit-export-asset-model.component';
import * as moment from 'moment';

@Component({
  selector: 'app-export-asset',
  templateUrl: './export-asset.component.html',
  styleUrls: ['./export-asset.component.css'],
  animations: [appModuleAnimation()]
})
export class ExportAssetComponent extends AppComponentBase implements AfterViewInit {
  @ViewChild('dataTable') dataTable: Table;
  @ViewChild('paginator') paginator: Paginator;
  @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditExportAssetModelComponent;
  public assetName: string

  constructor(injector: Injector, private _activatedRoute: ActivatedRoute, private _apiService: WebApiServiceProxy, ) {
    super(injector);
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.init();
    })
  }
  
  init() {
    this._activatedRoute.params.subscribe((params: Params) => {
      this.assetName = params['assetname'] || '';
      this.reloadList(this.assetName, null);
    });
  }

  refreshValueFromModal() {
    this.reLoadPage();
  }

  reloadList(name: string, event?: LazyLoadEvent): void {
    this._apiService.get('api/ExportAsset/GetExportAssetsByFilter',
      [{ fieldName: 'Name', value: this.assetName }],
      this.primengTableHelper.getSorting(this.dataTable),
      this.primengTableHelper.getMaxResultCount(this.paginator, event),
      this.primengTableHelper.getSkipCount(this.paginator, event),
    ).subscribe(result => {

      this.primengTableHelper.totalRecordsCount = result.totalCount;
      this.primengTableHelper.records = result.items;
      this.primengTableHelper.hideLoadingIndicator();
    });
  }

  formatDate(str: any): any {
    return moment(str).format('DD/MM/YYYY');
  }

  deleteExportAsset(id: number): void {
    this._apiService.delete("api/ExportAsset/DeleteExportAsset?", id)
      .subscribe(() => {
        this.notify.info(this.l('DeletedSuccessfully'));
        this.reLoadPage();
      });
  }
  reLoadPage() {
    this.paginator.changePage(this.paginator.getPage());
  }

  createExportAsset(): void {
    this.createOrEditModal.show();
  }

  applyFilters(): void {
    this.reloadList(this.assetName, null);

    if (this.paginator.getPage() != 0) {
      this.paginator.changePage(0);
    }
  }

  getExportAssets(event?: LazyLoadEvent) {
    if (!this.paginator || !this.dataTable) {
      return;
    } else {
      this.primengTableHelper.showLoadingIndicator();
      this.reloadList(null, event);
    }
  }

  truncateString(text: string): string {
    return abp.utils.truncateStringWithPostfix(text, 32, '...');
  }
}
