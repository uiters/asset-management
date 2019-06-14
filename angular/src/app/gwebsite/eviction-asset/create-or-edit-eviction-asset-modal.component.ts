import { Component, EventEmitter, Injector, Output, ViewChild, ElementRef } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { EvictionAssetDto } from '@app/gwebsite/eviction-asset/dto/eviction-asset.dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';

@Component({
    selector: 'createOrEditEvictionAssetModal',
    templateUrl: './create-or-edit-eviction-asset-modal.component.html'
})
export class CreateOrEditEvictionAssetModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('assetsCombobox') assetsCombobox: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    evictionAsset: EvictionAssetDto = new EvictionAssetDto();
    assets: ComboboxItemDto[] = [];
    // This
    isChange = this.evictionAsset.isReadonly;

    constructor(
        injector: Injector,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
        if (!this.evictionAsset.id) {
            this.evictionAsset.evictionDate = moment().format('DD/MM/YYYY');
        }
    }

    formatDate(): any {
        return moment().format('DD/MM/YYYY');
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

    show(id?: number | null | undefined): void {
        this.active = true;
        this.getAssets();

        this._apiService.getForEdit('api/EvictionAsset/GetEvictionAssetForEdit', id).subscribe(result => {
            this.evictionAsset = result;
            // This
            this.isChange = this.evictionAsset.isReadonly;
            if (!this.evictionAsset.id) {
                this.evictionAsset.evictionDate = moment().format('DD/MM/YYYY');
            }

            setTimeout(() => {
                $(this.assetsCombobox.nativeElement).selectpicker('refresh');
            }, 0);
            
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
        this.assets.forEach(item => {
            if (item.value === this.evictionAsset.assetCode) {
                this.evictionAsset.assetName = item.displayText;
            }
        });
        this._apiService.post('api/EvictionAsset/CreateEvictionAsset', this.evictionAsset)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    updateEvictionAsset() {
        this._apiService.put('api/EvictionAsset/UpdateAsset', this.evictionAsset)
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
