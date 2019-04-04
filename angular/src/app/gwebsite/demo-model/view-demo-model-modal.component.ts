import { DemoModelForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { DemoModelServiceProxy } from "@shared/service-proxies/service-proxies";
import { Router } from "@angular/router";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewDemoModelModal',
    templateUrl: './view-demo-model-modal.component.html'
})

export class ViewDemoModelModalComponent extends AppComponentBase {

    demoModel : DemoModelForViewDto;
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _demoModelService: DemoModelServiceProxy
    ) {
        super(injector);
    }

    show(demoModelId?: number | null | undefined): void {

        this._demoModelService.getDemoModelForView(demoModelId).subscribe(result => {
            this.demoModel = result;
            this.modal.show();
        })

    }
}