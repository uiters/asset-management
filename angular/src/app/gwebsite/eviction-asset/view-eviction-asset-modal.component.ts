import { AppComponentBase } from '@shared/common/app-component-base';
import { Injector, Component, ViewChild, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { EvictionAssetDto } from './dto/eviction-asset.dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
    selector: 'viewEvictionAssetModal',
    templateUrl: './view-eviction-asset-modal.component.html'
})
export class ViewEvictionAssetModalComponent extends AppComponentBase {
    @ViewChild('viewModal') modal: ModalDirective;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;

    evictionAsset: EvictionAssetDto = new EvictionAssetDto();

    constructor(injector: Injector, private _apiService: WebApiServiceProxy) {
        super(injector);
    }

    show(id: number): void {
        this._apiService
            .getForEdit('api/EvictionAsset/GetEvictionAssetForEdit', id)
            .subscribe(result => {
                this.evictionAsset = result;
                this.modal.show();
            });
    }

    close(): void {
        this.modal.hide();
    }
}
