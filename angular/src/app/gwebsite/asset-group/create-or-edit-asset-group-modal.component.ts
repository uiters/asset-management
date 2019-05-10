import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { AssetGroupDto } from '@app/gwebsite/asset-group/dto/asset-group.dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'createOrEditAssetGroupModal',
  templateUrl: './create-or-edit-asset-group-modal.component.html'
})
export class CreateOrEditAssetGroupModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('assetGroupCombobox') assetGroupCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    assetGroup: AssetGroupDto = new AssetGroupDto();
    assetGroups: ComboboxItemDto[] = [];

    constructor(
        injector: Injector,
        private _apiService: WebApiServiceProxy
    ) {
        super(injector);
    }

    show(assetGroupId?: number | null | undefined): void {
        this.active = true;

        this._apiService.getForEdit('api/GroupAsset/GetGroupAssetForEdit', assetGroupId).subscribe(result => {
            this.assetGroup = result;
            this.modal.show();
            setTimeout(() => {
                    $(this.assetGroupCombobox.nativeElement).selectpicker('refresh');
            }, 0);
        });
    }

    save(): void {
        let input = this.assetGroup;
        this.saving = true;
        if (input.id) {
            this.updateAssetGroup();
        } else {
            this.insertAssetGroup();
        }
    }

    insertAssetGroup() {
        this._apiService.post('api/GroupAsset/CreateGroupAsset', this.assetGroup)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    updateAssetGroup() {
        this._apiService.put('api/GroupAsset/UpdateGroupAsset', this.assetGroup)
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
