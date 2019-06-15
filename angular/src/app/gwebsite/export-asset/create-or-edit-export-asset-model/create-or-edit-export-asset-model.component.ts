import { Component, ViewChild, ElementRef, Output, EventEmitter, Injector } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { ExportAssetDto, ComboboxItemDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { finalize } from 'rxjs/operators';
import * as moment from 'moment';
@Component({
  selector: 'app-create-or-edit-export-asset-model',
  templateUrl: './create-or-edit-export-asset-model.component.html',
  styleUrls: ['./create-or-edit-export-asset-model.component.css']
})
export class CreateOrEditExportAssetModelComponent extends AppComponentBase {
  @ViewChild('createOrEditModal') modal: ModalDirective;
  @ViewChild('unitCombobox') unitCombobox: ElementRef;
  @ViewChild('assetCombobox') assetCombobox: ElementRef;
  @ViewChild('userCombobox') userCombobox: ElementRef;

  @ViewChild('warrantyPeriod') warrantyPeriod: ElementRef;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  public active: boolean = false;
  public saving: boolean = false;
  public exportAsset: ExportAssetDto = new ExportAssetDto();

  public assetsCombobox: ComboboxItemDto[] = [];
  public unitsCombobox: ComboboxItemDto[] = [];
  public users: ComboboxItemDto[] = [];
  public str: string;

  constructor(injector: Injector,
    private _appService: WebApiServiceProxy, ) {
    super(injector);
  }


  formatDate(): string {
    return this.str; 
  }

  save(): void {
    let input = this.exportAsset;
    input.isReadonly = false;

    this.saving = true;
    if (input.id)
      this.update(input);
    else
      this.create(input);
  }

  update(input: ExportAssetDto): void {
    this._appService.put('api/ExportAsset/UpdateExportAsset', input)
      .pipe(finalize(() => this.saving = false))
      .subscribe(result => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close();
      });
  }

  create(input: ExportAssetDto): void {
    input.exportDate = moment(Date.now());
    this._appService.post('api/ExportAsset/CreateExportAsset', input)
      .pipe(finalize(() => this.saving = false))
      .subscribe(result => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close();
      });
  }

  close(): void {
    this.modal.hide();
    this.modalSave.emit(null);
    this.active = false;

  }

  show(id?: number | null | undefined): void {
    this.active = true;
    if (!id || id == undefined) {
      this.str = moment().format('DD/MM/YYYY');
      this.exportAsset = new ExportAssetDto();


      this.exportAsset.isReadonly = false;
      this.getAssetComboBox();
      this.getUnitsComboBox();
      // this.getUserComboBox();
      this.modal.show();
    } else {
      
      this._appService.getForEdit('api/ExportAsset/GetExportAssetForEdit', id)
        .subscribe(exportAssetAsset => {
          this.exportAsset = exportAssetAsset;
          this.str = moment(this.exportAsset.exportDate).format('DD/MM/YYYY');

          this.getAssetComboBox();
          this.getUnitsComboBox();
          // this.getUserComboBox();
          this.modal.show();
        });
    }


  }

  getAssetComboBox(): void {
    this._appService.get('api/Asset/GetAssets')
      .subscribe(
        assets => {
          this.assetsCombobox = assets.items.map<ComboboxItemDto>(item => 
            new ComboboxItemDto({value: item.assetCode, displayText: item.assetName, isSelected: false}));
          setTimeout(() => {
            $(this.assetCombobox.nativeElement).selectpicker("refresh");
          }, 0);
        }
      );
  }

  getUnitsComboBox(): void {
    this._appService.getForEdit('api/Unit/GetUnitCombobox', 0)
      .subscribe(
        unitsCombobox => {
          this.unitsCombobox = unitsCombobox.units;
          
          setTimeout(() => {
            $(this.unitCombobox.nativeElement).selectpicker("refresh");
          }, 0);
        }
      );
  }

  onSelectAsset(name: string): void { 
    this._appService.get('api/Asset/GetAssetByCode?code=' + name)
      .subscribe(
        asset => {
          this.exportAsset.assetName = asset.items && asset.items[0].assetName;
        }
      );
  }
}
