import { CustomerForViewDto } from "./../../../shared/service-proxies/service-proxies";
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { CustomerServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: "app-view-asset-group-modal",
    templateUrl: "./view-asset-group-modal.component.html"
})
export class ViewAssetGroupModalComponent extends AppComponentBase {
    constructor(injector: Injector) {
        super(injector);
    }
}
