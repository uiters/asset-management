import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { MenuClientDto } from '@app/gwebsite/depreciation/dto/depreciation.dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createOrEditMenuClientModal',
    templateUrl: './create-or-edit-depreciation-modal.component.html'
})
export class CreateOrEditMenuClientModalComponent extends AppComponentBase {

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
        this._apiService.getForEdit('api/Depreciation/GetDepreciationForEdit', menuClientId).subscribe(result => {
            this.menuClient = result.depreciation;
            console.log(this.menuClient);
            this.menuClients = result.menuClients;
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
        this._apiService.post('api/Depreciation/CreateDepreciation', this.menuClient)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    updateMenuClient() {
        this._apiService.put('api/Depreciation/UpdateDepreciation', this.menuClient)
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
    onChangeDepreciationMonths(value: string | number): void {
        console.log(value);
        //let originalprice:number = this.menuClient.remainingValue+this.menuClient.depreciatedValue;
        //console.log(originalprice);
        if (value != null && !isNaN(Number(value.toString()))) {
          if (Number(value) <= 0)
            this.menuClient.depreciationRateByYear = undefined;
          else
            this.menuClient.depreciationRateByYear = ((1/Number(value))*100);
        }else {
          this.menuClient.depreciationRateByYear = undefined;
        }
      }
}
