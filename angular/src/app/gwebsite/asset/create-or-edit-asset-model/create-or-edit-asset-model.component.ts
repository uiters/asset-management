import { Component, AfterViewInit, ViewChild, ElementRef, Output, EventEmitter, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { AssetServiceProxy, AssetInput, ComboboxItemDto, GroupAssetServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import * as moment from 'moment';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { log } from 'util';

@Component({
  selector: 'appCreateOrEditAssetModel',
  templateUrl: './create-or-edit-asset-model.component.html',
})
export class CreateOrEditAssetModelComponent extends AppComponentBase {

  @ViewChild('createOrEditModal') modal: ModalDirective;
  @ViewChild('groupAssetCombobox') groupAssetCombobox: ElementRef;
  @ViewChild('assetTypeCombobox') assetTypeCombobox: ElementRef;
  @ViewChild('warrantyPeriod') warrantyPeriod: ElementRef;

  /**
   * Public method
   */
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  public saving: boolean = false;
  public asset: AssetInput = new AssetInput();
  public groupAssets: ComboboxItemDto[] = [];
  public assetTypes: ComboboxItemDto[] = [];

  public hasValue: boolean = true;

  constructor(
    injector: Injector,
    private _appService: WebApiServiceProxy,
    private _assetService: AssetServiceProxy,
    private _groupAsset: GroupAssetServiceProxy
  ) {
    super(injector);
    if (!this.asset.id) {
      this.asset.dayImport = moment(Date.now());
      this.asset.depreciationRateByYear = 0;
    }
  }

  save(): void {
    let input = this.asset;
    this.saving = true;
    if (input.id)
      this.updateAsset(input);
    else
      this.createAsset(input);
  }

  updateAsset(input: AssetInput): void {

    this._appService.post('api/Asset/UpdateAsset', input)
      .pipe(finalize(() => this.saving = false))
      .subscribe(result => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close();
      });
  }

  createAsset(input: AssetInput): void {
    input.warrantyPeriod = input.dayImport;
    this._appService.post('api/Asset/CreateAsset', input)
      .pipe(finalize(() => this.saving = false))
      .subscribe(result => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close();
      });
  }

  close(): void {
    this.modal.hide();
    this.modalSave.emit(null);
  }

  onSelectGroupAsset(id?: number | null | undefined): void {
    if (!id)
      return;
    this._appService.getForEdit('api/GroupAsset/GetGroupAssetForEdit', id)
      .subscribe(
        groupAsset => {
          if (groupAsset)
            this.hasValue = groupAsset.depreciationMonths != 0
          if (this.hasValue)
          {
            this.asset.depreciationRateByYear = (1 / groupAsset.depreciationMonths) * 100;
            this.asset.depreciationMonths = groupAsset.depreciationMonths;
          }
          // setTimeout(() => {
          //   $(this.groupAssetCombobox.nativeElement).selectpicker("refresh");
          // }, 0);
        }
      );
  }

  show(id?: number | null | undefined): void {

    this._appService.getForEdit('api/GroupAsset/GetGroupAssetCombobox', id)
      .subscribe(
        groupAssetscombobox => {
          this.groupAssets = groupAssetscombobox.groupAssets;
          setTimeout(() => {
            $(this.groupAssetCombobox.nativeElement).selectpicker("refresh");
          }, 0);
        }
      );
    this._appService.getForEdit('api/AssetType/GetAssetTypeCombobox', 1)
      .subscribe(
        assetTypesCombobox => {
          this.assetTypes = assetTypesCombobox.assetTypes;
          setTimeout(() => {
            $(this.assetTypeCombobox.nativeElement).selectpicker("refresh");
          }, 0);
        }
      );
    if (!id) {
      this.asset.dayImport = moment(Date.now());
      this.asset.depreciationRateByYear = 0;
      this.modal.show();
    } else {
      this._appService.getForEdit('api/Asset/GetAssetForEdit', id)
        .subscribe(asset => {
          this.asset = asset;
          this.modal.show();
        });
    }
  }

}
