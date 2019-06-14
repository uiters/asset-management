import { AppComponentBase } from "@shared/common/app-component-base";
import { Injector, Component, ViewChild, ElementRef } from "@angular/core";
import { ModalDirective } from "ngx-bootstrap";
import { WebApiServiceProxy } from "@shared/service-proxies/webapi.service";
import { AssetTypeDto } from "@shared/service-proxies/service-proxies";

@Component({
    selector: "viewAssetTypeModal",
    templateUrl: "./view-asset-type-modal.component.html"
})
export class ViewAssetTypeModalComponent extends AppComponentBase {
    @ViewChild('viewModal') modal: ModalDirective;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;

    assetType: AssetTypeDto = new AssetTypeDto();

    constructor(
        injector: Injector,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }

    show(id: number): void {
        this._apiService.getForEdit('api/AssetType/GetAssetTypeForEdit', id).subscribe(result => {
            this.assetType = result;
            this.modal.show();
        });
    }

    close(): void {
        this.modal.hide();
    }
}
