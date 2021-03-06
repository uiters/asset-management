import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { MenuClientDto } from '@app/gwebsite/unit/dto/unit.dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createOrEditUnitModal',
    templateUrl: './create-or-edit-unit-modal.component.html'
})
export class CreateOrEditUnitModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('menuClientCombobox') menuClientCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    menuClient: MenuClientDto = new MenuClientDto();
    menuClients: ComboboxItemDto[] = [];
    
    constructor(
        injector: Injector,
        private _apiService: WebApiServiceProxy
    ) {
        super(injector);
    }

    show(menuClientId?: number | null | undefined): void {
        this.active = true;
        //console.log(menuClientId);
        this._apiService.getForEdit('api/Unit/GetUnitForEdit', menuClientId).subscribe(result => {
            this.menuClient = result.unit;
            console.log(this.menuClient);
            this.menuClients = result.units;
            this.modal.show();
            setTimeout(() => {
                    $(this.menuClientCombobox.nativeElement).selectpicker('refresh');
            }, 0);
        });
        
    }

    save(): void {
        let input = this.menuClient;
        this.saving = true;
        if (input.id) {
            this.updateMenuClient();
        } else {
            this.insertMenuClient();
        }
    }

    insertMenuClient() {
        this.menuClient.name="string";
        this._apiService.post('api/Unit/CreateUnit', this.menuClient)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    updateMenuClient() {
        this._apiService.put('api/Unit/UpdateUnit', this.menuClient)
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
