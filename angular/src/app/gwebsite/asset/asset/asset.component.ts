import { Component, AfterViewInit, ViewChild, Injector } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { Table } from 'primeng/table';
import { Paginator, LazyLoadEvent } from 'primeng/primeng';
import { ActivatedRoute, Params } from '@angular/router';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { CreateOrEditAssetModelComponent } from '../create-or-edit-asset-model/create-or-edit-asset-model.component';
import * as moment from 'moment';

@Component({
  selector: 'appAsset',
  templateUrl: './asset.component.html',
  animations: [appModuleAnimation()]
})
export class AssetComponent extends AppComponentBase implements AfterViewInit {

  @ViewChild('dataTable') dataTable: Table;
  @ViewChild('paginator') paginator: Paginator;
  @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditAssetModelComponent;
  // @ViewChild('viewCustomerModal') viewCustomerModal: ViewCustomerModalComponent;

  //Properties
  public assetName: string

  constructor(
    injector: Injector,
    private _apiService: WebApiServiceProxy,
    private _activatedRoute: ActivatedRoute
  ) { super(injector) }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.init();
    })
  }
  init() {
    this._activatedRoute.params.subscribe((params: Params) => {
      this.assetName = params['assetname'] || '';
      this.reloadList(null);
    });
  }
  reloadList(event?: LazyLoadEvent): void {
    this._apiService.get('api/Asset/GetAssetsByFilter',
      [{ fieldName: 'AssetName', value: this.assetName }],
      this.primengTableHelper.getSorting(this.dataTable),
      this.primengTableHelper.getMaxResultCount(this.paginator, event),
      this.primengTableHelper.getSkipCount(this.paginator, event),
    ).subscribe(result => {
      console.log(this.assetName, result);

      this.primengTableHelper.totalRecordsCount = result.totalCount;
      this.primengTableHelper.records = result.items;
      this.primengTableHelper.hideLoadingIndicator();
    });
  }

  deleteAsset(id: number): void {
    this._apiService.delete("api/Asset/DeleteAsset?", id)
      .subscribe(() => {
        this.notify.info(this.l('DeletedSuccessfully'));
        this.reLoadPage();
      });
  }
  reLoadPage() {
    this.paginator.changePage(this.paginator.getPage());
  }

  formatDate(str: any): any {
    return moment(str).format('DD/MM/YYYY');
  }

  createAsset(): void {
    this.createOrEditModal.show();
  }

  applyFilters(): void {
    this.reloadList(null);

    if (this.paginator.getPage() != 0) {
      this.paginator.changePage(0);
    }
  }

  getAssets(event?: LazyLoadEvent) {
    if (!this.paginator || !this.dataTable) {
      return;
    } else {
      this.primengTableHelper.showLoadingIndicator();
      this.reloadList(event);
    }
  }

  truncateString(text: string): string {
    return abp.utils.truncateStringWithPostfix(text, 32, '...');
  }

}
