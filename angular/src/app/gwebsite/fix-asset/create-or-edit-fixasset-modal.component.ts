import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { MenuClientDto } from '@app/gwebsite/fix-asset/dto/fixasset.dto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';
@Component({
    selector: 'createOrEditFixAssetModal',
    templateUrl: './create-or-edit-fixasset-modal.component.html'
})
export class CreateOrEditFixAssetModalComponent extends AppComponentBase {

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
        if(!this.menuClient.id)
        {
           // console.log('asdasd');
            this.menuClient.dayBeginFix = moment(Date.now());
            //console.log(moment(Date.now()));
        }
    }
    formatDate(): any {
        return moment().format('DD/MM/YYYY');
      }
    show(menuClientId?: number | null | undefined): void {
        this.active = true;
        //console.log(moment(Date.now()));
        //console.log(menuClientId);
        this._apiService.getForEdit('api/FixAsset/GetFixAssetForEdit', menuClientId).subscribe(result => {
            this.menuClient = result.fixAsset;
            //console.log(this.menuClient);
            this.menuClients = result.fixAssets;
            this.modal.show();
            setTimeout(() => {
                    $(this.menuClientCombobox.nativeElement).selectpicker('refresh');
            }, 0);
        });
        this._apiService.getForEdit('api/Asset/GetAssetCombobox', 1)
      .subscribe(
        assetTypesCombobox => {
          this.menuClients = assetTypesCombobox.assets;
          //console.log(this.menuClients);
          setTimeout(() => {
            $(this.menuClientCombobox.nativeElement).selectpicker("refresh");
          }, 0);
        }
      );
      if(!this.menuClient.id)
      {
          //console.log("A");
          this.menuClient.dayBeginFix = moment(Date.now());
          console.log(moment(Date.now()));
      }
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
        this.menuClient.dayBeginFix = moment(Date.now());
        this.menuClient.name="string";
        this._apiService.post('api/FixAsset/CreateFixAsset', this.menuClient)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    updateMenuClient() {
        this._apiService.put('api/FixAsset/UpdateFixAsset', this.menuClient)
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
