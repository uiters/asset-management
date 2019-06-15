import { Component, AfterViewInit, ViewChild, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { Table } from 'primeng/table';
import { Paginator, LazyLoadEvent } from 'primeng/primeng';
import { ActivatedRoute, Params } from '@angular/router';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { CreateOrEditTransferAssetComponent } from '../create-or-edit-transfer-asset/create-or-edit-transfer-asset.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import * as moment from 'moment';

@Component({
  selector: 'app-transfer-asset',
  templateUrl: './transfer-asset.component.html',
  animations: [appModuleAnimation()]

})
export class TransferAssetComponent extends AppComponentBase implements AfterViewInit {

  @ViewChild('dataTable') dataTable: Table;
  @ViewChild('paginator') paginator: Paginator;
  @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditTransferAssetComponent;
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
  reloadList(name: string, event?: LazyLoadEvent): void {
    this._apiService.get('api/TransferAsset/GetTransferAssetsByFilter',
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

  deleteTransferAsset(id: number): void {
    this._apiService.delete("api/TransferAsset/DeleteTransferAsset?", id)
      .subscribe(() => {
        this.notify.info(this.l('DeletedSuccessfully'));
        this.reLoadPage();
      });
  }
  reLoadPage() {
    this.paginator.changePage(this.paginator.getPage());
  }

  createTransferAsset(): void {
    this.createOrEditModal.show();
  }

  applyFilters(): void {
    this.reloadList(this.assetName, null);

    if (this.paginator.getPage() != 0) {
      this.paginator.changePage(0);
    }
  }

  getTransferAssets(event?: LazyLoadEvent) {
    if (!this.paginator || !this.dataTable) {
      return;
    } else {
      this.primengTableHelper.showLoadingIndicator();
      this.reloadList(null, event);
    }
  }

  formatDate(str: any): any {
    return moment(str).format('DD/MM/YYYY');
  }

  truncateString(text: string): string {
    return abp.utils.truncateStringWithPostfix(text, 32, '...');
  }
}
