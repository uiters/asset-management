import { Component, ViewChild, ElementRef, Output, EventEmitter, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { AssetServiceProxy, AssetInput, ComboboxItemDto, GroupAssetServiceProxy, DepreciationDto } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import * as moment from 'moment';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
  selector: 'appCreateOrEditAssetModel',
  templateUrl: './create-or-edit-asset-model.component.html',
})
export class CreateOrEditAssetModelComponent extends AppComponentBase {

  @ViewChild('createOrEditModal') modal: ModalDirective;
  @ViewChild('groupAssetCombobox') groupAssetCombobox: ElementRef;
  // @ViewChild('assetTypeCombobox') assetTypeCombobox: ElementRef;
  @ViewChild('warrantyPeriod') warrantyPeriod: ElementRef;

  /**
   * Public method
   */
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  public saving: boolean = false;
  public asset: AssetInput = new AssetInput();
  public groupAssets: ComboboxItemDto[] = [];
  public assetTypes: ComboboxItemDto[] = [];

  public temp: DepreciationDto = new DepreciationDto();
  public hasValue: boolean = true;
  // This
  isChange = this.asset.isReadonly;

  constructor(
    injector: Injector,
    private _appService: WebApiServiceProxy,
    private _assetService: AssetServiceProxy,
    private _groupAsset: GroupAssetServiceProxy
  ) {
    super(injector);
    if (!this.asset.id) {
      this.asset.dayImport = moment(Date.now());
      this.asset.depreciationMonths = 0;
      this.asset.depreciationRateByYear = 0;
    }
  }

  formatDate(): any {
    return moment().format('DD/MM/YYYY');
  }

  save(): void {
    let input = this.asset;
    if (input.depreciationRateByYear == undefined) {
      this.notify.warn(this.l('Số tháng khấu hao không hợp lệ'));
      return;
    }
    this.saving = true;
    if (input.id)
      this.updateAsset(input);
    else
      this.createAsset(input);
  }

  updateAsset(input: AssetInput): void {

    this._appService.put('api/Asset/UpdateAsset', input)
      .pipe(finalize(() => this.saving = false))
      .subscribe(result => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close();
      });
      
      
      console.log(this.temp);
      this.temp.remainingValue = input.originalPrice-this.temp.depreciatedValue;
      this.temp.assetCode = input.assetCode;
      this.temp.depreciationMonths = input.depreciationMonths;
      this.temp.depreciationRateByYear = input.depreciationRateByYear;
      this._appService.put('api/Depreciation/UpdateDepreciation', this.temp)
      .pipe(finalize(() => this.saving = false))
      .subscribe(result => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close();
      });
  }

  createAsset(input: AssetInput): void {

    input.warrantyPeriod = moment(input.warrantyPeriod);
    this._appService.get('api/Asset/GetAssetByCode?code=' + input.assetCode)
      .subscribe(asset => {
        console.log(asset);
        if (asset.items != null && asset.items[0]) {
          this.notify.warn(this.l('Mã tài sản đã tồn tại'));
          this.saving = false;
        } else {
          this._appService.post('api/Asset/CreateAsset', input)
            .pipe(finalize(() => this.saving = false))
            .subscribe(result => {
              this.notify.info(this.l('SavedSuccessfully'));
              this.close();
            });
            let inputde = new DepreciationDto();
            inputde.assetCode = input.assetCode;
            inputde.dayBeginCalculateDepreciation = input.dayImport;
            inputde.depreciatedValue = 0;
            inputde.depreciationCode ="KH"+inputde.assetCode;
            inputde.depreciationMonths = input.depreciationMonths;
            inputde.depreciationRateByYear = input.depreciationRateByYear;
            inputde.remainingValue =parseFloat(input.originalPrice.toString());
            inputde.isDeleted = false;
            inputde.name = "string";
            this._appService.post('api/Depreciation/CreateDepreciation', inputde)
            .pipe(finalize(() => this.saving = false))
            .subscribe(result => {
              this.notify.info(this.l('SavedSuccessfully'));
              this.close();
            });
        }
      })

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
          if (this.hasValue) {
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
    //this._groupAsset.getGroupAssets().subscribe(assets => console.log(assets));
    this._appService.getForEdit('api/GroupAsset/GetGroupAssetCombobox', id)
      .subscribe(
        groupAssetscombobox => {
          this.groupAssets = groupAssetscombobox.groupAssets;
          setTimeout(() => {
            $(this.groupAssetCombobox.nativeElement).selectpicker("refresh");
          }, 0);
        }
      );
    // this._appService.getForEdit('api/AssetType/GetAssetTypeCombobox', 1)
    //   .subscribe(
    //     assetTypesCombobox => {
    //       this.assetTypes = assetTypesCombobox.assetTypes;
    //       setTimeout(() => {
    //         $(this.assetTypeCombobox.nativeElement).selectpicker("refresh");
    //       }, 0);
    //     }
    //   );
    if (!id) {
      this.asset.dayImport = moment(Date.now());
      this.asset.depreciationRateByYear = 0;
      this.modal.show();
    } else {
      this._appService.getForEdit('api/Asset/GetAssetForEdit', id)
        .subscribe(asset => {
          this.asset = asset;
          // This
          this.isChange = this.asset.isReadonly;
          this.modal.show();
        });
        this._appService.getForEdit('api/Depreciation/GetDepreciationForEdit',id)
      .subscribe(result=>{
        this.temp = result.depreciation;
      })
    }
  }
  onChangeDepreciationMonths(value: string | number): void {
    console.log(value);
    if (value != null && !isNaN(Number(value.toString()))) {
      if (Number(value) <= 0)
        this.asset.depreciationRateByYear = undefined;
      else
        this.asset.depreciationRateByYear = 1 / Number(value);
    }else {
      this.asset.depreciationRateByYear = undefined;
    }
  }
}
