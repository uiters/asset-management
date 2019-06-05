import { Component, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { AssetTypeDto } from '@app/gwebsite/asset-type/dto/asset-type.dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

const thinid = require('thinid');

@Component({
    selector: 'createOrEditAssetTypeModal',
    templateUrl: './create-or-edit-asset-type-modal.component.html'
})
export class CreateOrEditAssetTypeModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    assetType: AssetTypeDto = new AssetTypeDto();
    // This
    isChange = this.assetType.isReadonly;

    constructor(
        injector: Injector,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }

    show(assetTypeId?: number | null | undefined): void {
        this.active = true;

        this._apiService.getForEdit('api/AssetType/GetAssetTypeForEdit', assetTypeId).subscribe(result => {
            this.assetType = result;
            // This
            this.isChange = this.assetType.isReadonly;
            if (!this.assetType.id) {
                this.assetType.assetTypeCode = 'LTS-' + thinid(8);
            }
            this.modal.show();
        });
    }

    save(): void {
        let input = this.assetType;
        this.saving = true;
        if (input.id) {
            this.updateAssetType();
        } else {
            this.insertAssetType();
        }
    }

    insertAssetType() {
        this._apiService.post('api/AssetType/CreateAssetType', this.assetType)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    updateAssetType() {
        this._apiService.put('api/AssetType/UpdateAssetType', this.assetType)
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
