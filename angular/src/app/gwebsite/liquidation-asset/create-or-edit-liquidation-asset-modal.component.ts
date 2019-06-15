import { Component, EventEmitter, Injector, Output, ViewChild, ElementRef } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { LiquidationAssetDto } from './dto/liquidation-asset.dto';
import * as moment from 'moment';
import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createOrEditLiquidationAssetModal',
    templateUrl: './create-or-edit-liquidation-asset-modal.component.html'
})
export class CreateOrEditLiquidationAssetModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('assetsCombobox') assetsCombobox: ElementRef;
    @ViewChild('unitsCombobox') unitsCombobox: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    liquidationAsset: LiquidationAssetDto = new LiquidationAssetDto();
    assets: ComboboxItemDto[] = [];
    units: ComboboxItemDto[] = [];
    // This
    isChange = this.liquidationAsset.isReadonly;

    constructor(
        injector: Injector,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
        if (!this.liquidationAsset.id) {
            this.liquidationAsset.liquidationDate = moment().format('DD/MM/YYYY');
        }
    }

    getAssets() {
        this._apiService.getForEdit('api/Asset/GetAssetCombobox', 1
        ).subscribe(result => {
            this.assets = result.assets;
            setTimeout(() => {
                $(this.assetsCombobox.nativeElement).selectpicker('refresh');
            }, 0);
        });
    }

    getUnits() {
        this._apiService.getForEdit('api/Unit/GetUnitCombobox', 1
        ).subscribe(result => {
            this.units = result.units;
            setTimeout(() => {
                $(this.unitsCombobox.nativeElement).selectpicker('refresh');
            }, 0);
        });
    }

    show(id?: number | null | undefined): void {
        this.active = true;
        
        this.getAssets();
        this.getUnits();

        this._apiService.getForEdit('api/LiquidationAsset/GetLiquidationAssetForEdit', id).subscribe(result => {
            this.liquidationAsset = result;
            // This
            this.isChange = this.liquidationAsset.isReadonly;
            if (!this.liquidationAsset.id) {
                this.liquidationAsset.liquidationDate = moment().format('DD/MM/YYYY');
            }
            setTimeout(() => {
                $(this.assetsCombobox.nativeElement).selectpicker('refresh');
                $(this.unitsCombobox.nativeElement).selectpicker('refresh');
            }, 0);
            this.modal.show();
        });
    }

    save(): void {
        let input = this.liquidationAsset;
        this.saving = true;
        if (input.id) {
            this.update();
        } else {
            this.insert();
        }
    }

    insert() {
        this.assets.forEach(item => {
            if (item.value === this.liquidationAsset.assetCode) {
                this.liquidationAsset.assetName = item.displayText;
            }
        });
        this._apiService.post('api/LiquidationAsset/CreateLiquidationAsset', this.liquidationAsset)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    update() {
        this._apiService.put('api/LiquidationAsset/UpdateLiquidationAsset', this.liquidationAsset)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
