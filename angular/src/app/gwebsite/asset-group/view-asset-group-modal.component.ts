import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild, ElementRef } from "@angular/core";
import { ModalDirective } from "ngx-bootstrap";
import { AssetGroupDto } from "./dto/asset-group.dto";
import { WebApiServiceProxy } from "@shared/service-proxies/webapi.service";
import { ComboboxItemDto } from "@shared/service-proxies/service-proxies";

@Component({
    selector: "viewAssetGroupModal",
    templateUrl: "./view-asset-group-modal.component.html"
})
export class ViewAssetGroupModalComponent extends AppComponentBase {
    @ViewChild('viewModal') modal: ModalDirective;
    @ViewChild('assetGroupsCombobox') assetGroupsCombobox: ElementRef;
    @ViewChild('assetTypesCombobox') assetTypesCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;

    assetGroup: AssetGroupDto = new AssetGroupDto();
    assetGroups: ComboboxItemDto[] = [];
    assetTypes: ComboboxItemDto[] = [];

    constructor(
        injector: Injector,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }

    show(id: number): void {
        this._apiService.getForEdit('api/GroupAsset/GetGroupAssetForEdit', id).subscribe(result => {
            this.assetGroup = result;
            this.modal.show();
        });
    }

    getAssetGroups() {
        this._apiService.getForEdit('api/GroupAsset/GetGroupAssetCombobox', 1
        ).subscribe(result => {
            this.assetGroups = result.groupAssets;
            setTimeout(() => {
                $(this.assetGroupsCombobox.nativeElement).selectpicker('refresh');
        }, 0);
        });
    }

    getAssetTypes() {
        this._apiService.getForEdit('api/AssetType/GetAssetTypeCombobox', 1
        ).subscribe(result => {
            this.assetTypes = result.assetTypes;
            setTimeout(() => {
                $(this.assetTypesCombobox.nativeElement).selectpicker('refresh');
        }, 0);
        });
    }

    close() : void{
        this.modal.hide();
    }
}
