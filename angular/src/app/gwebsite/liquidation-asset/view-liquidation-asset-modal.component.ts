import { AppComponentBase } from '@shared/common/app-component-base';
import { Injector, Component, ViewChild, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { LiquidationAssetDto } from './dto/liquidation-asset.dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
    selector: 'viewLiquidationAssetModal',
    templateUrl: './view-liquidation-asset-modal.component.html'
})
export class ViewLiquidationAssetModalComponent extends AppComponentBase {
    @ViewChild('viewModal') modal: ModalDirective;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;

    liquidationAsset: LiquidationAssetDto = new LiquidationAssetDto();

    constructor(injector: Injector, private _apiService: WebApiServiceProxy) {
        super(injector);
    }

    show(id: number): void {
        this._apiService
            .getForEdit('api/LiquidationAsset/GetLiquidationAssetForEdit', id)
            .subscribe(result => {
                this.liquidationAsset = result;
                this.modal.show();
            });
    }

    close(): void {
        this.modal.hide();
    }
}
