import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild, AfterViewInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { DemoModelServiceProxy, DemoModelInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditDemoModelModal',
    templateUrl: './create-or-edit-demo-model-modal.component.html'
})
export class CreateOrEditDemoModelModalComponent extends AppComponentBase implements AfterViewInit {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('demoModelCombobox') demoModelCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    demoModel: DemoModelInput = new DemoModelInput();

    constructor(
        injector: Injector,
        private _demoModelService: DemoModelServiceProxy,
        private _apiService: WebApiServiceProxy
    ) {
        super(injector);
    }

    ngAfterViewInit(): void {
        let t = this;
        $(this.dateInput.nativeElement).datetimepicker({
            locale: abp.localization.currentLanguage.name,
            format: 'L'
        }).on('dp.change', function (e) {
            t.demoModel.date = $(t.dateInput.nativeElement).val().toString();
        });
    }



    show(demoModelId?: number | null | undefined): void {
        this.saving = false;


        this._demoModelService.getDemoModelForEdit(demoModelId).subscribe(result => {
            this.demoModel = result;
            // debugger
            this.modal.show();

        })
    }

    save(): void {
        let input = this.demoModel;
        this.saving = true;
        this._demoModelService.createOrEditDemoModel(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
