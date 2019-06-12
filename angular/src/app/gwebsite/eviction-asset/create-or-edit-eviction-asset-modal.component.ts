import { Component, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { EvictionAssetDto } from '@app/gwebsite/eviction-asset/dto/eviction-asset.dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
    selector: 'createOrEditEvictionAssetModal',
    templateUrl: './create-or-edit-eviction-asset-modal.component.html'
})
export class CreateOrEditEvictionAssetModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    evictionAsset: EvictionAssetDto = new EvictionAssetDto();
    // This
    isChange = this.evictionAsset.isReadonly;

    constructor(
        injector: Injector,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }

    show(id?: number | null | undefined): void {
        this.active = true;

        this._apiService.getForEdit('api/EvictionAsset/GetEvictionAssetForEdit', id).subscribe(result => {
            this.evictionAsset = result;
            // This
            this.isChange = this.evictionAsset.isReadonly;
            this.modal.show();
        });
    }

    save(): void {
        let input = this.evictionAsset;
        this.saving = true;
        if (input.id) {
            this.updateEvictionAsset();
        } else {
            this.insertEvictionAsset();
        }
    }

    insertEvictionAsset() {
        this._apiService.post('api/EvictionAsset/CreateEvictionAsset', this.evictionAsset)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    updateEvictionAsset() {
        this._apiService.put('api/EvictionAsset/UpdateEvictionAsset', this.evictionAsset)
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
