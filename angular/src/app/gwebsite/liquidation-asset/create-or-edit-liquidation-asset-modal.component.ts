import { Component, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { LiquidationAssetDto } from './dto/liquidation-asset.dto';

@Component({
    selector: 'createOrEditLiquidationAssetModal',
    templateUrl: './create-or-edit-liquidation-asset-modal.component.html'
})
export class CreateOrEditLiquidationAssetModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    liquidationAsset: LiquidationAssetDto = new LiquidationAssetDto();
    // This
    isChange = this.liquidationAsset.isReadonly;

    constructor(
        injector: Injector,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }

    show(id?: number | null | undefined): void {
        this.active = true;

        this._apiService.getForEdit('api/LiquidationAsset/GetLiquidationAssetForEdit', id).subscribe(result => {
            this.liquidationAsset = result;
            // This
            this.isChange = this.liquidationAsset.isReadonly;
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
