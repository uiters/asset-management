import { CustomerServiceProxy, AssetServiceProxy, AssetTypeServiceProxy, GroupAssetServiceProxy } from './../../shared/service-proxies/service-proxies';
import { ViewDemoModelModalComponent } from './demo-model/view-demo-model-modal.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { UtilsModule } from '@shared/utils/utils.module';
import { FileUploadModule } from 'ng2-file-upload';
import { ModalModule, PopoverModule, TabsModule, TooltipModule } from 'ngx-bootstrap';
import { AutoCompleteModule, EditorModule, FileUploadModule as PrimeNgFileUploadModule, InputMaskModule, PaginatorModule } from 'primeng/primeng';
import { TableModule } from 'primeng/table';
import { GWebsiteRoutingModule } from './gwebsite-routing.module';

import { 
    FixAssetComponent,
    CreateOrEditFixAssetModalComponent,
    AssetGroupComponent,
    CreateOrEditAssetGroupModalComponent,
    ViewAssetGroupModalComponent,
    AssetTypeComponent,
    CreateOrEditAssetTypeModalComponent,
    ViewAssetTypeModalComponent,
    UnitComponent,
    CreateOrEditUnitModalComponent,
} from './index';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { MenuClientComponent as DepreciationComponent } from './depreciation/depreciation.component';
import { CreateOrEditMenuClientModalComponent as CreateOrEditDepreciationModalComponent } from'./depreciation/create-or-edit-depreciation-modal.component';
import { CreateOrEditDemoModelModalComponent } from './demo-model/create-or-edit-demo-model-modal.component';
import { DemoModelServiceProxy } from '@shared/service-proxies/service-proxies';
import { CustomerComponent } from './customer/customer.component';
import { ViewCustomerModalComponent } from './customer/view-customer-modal.component';
import { CreateOrEditCustomerModalComponent } from './customer/create-or-edit-customer-modal.component';
import { from } from 'rxjs';
import { CreateOrEditAssetModelComponent } from './asset/create-or-edit-asset-model/create-or-edit-asset-model.component';
import { AssetComponent } from './asset/asset/asset.component';
import { ExportAssetComponent } from './export-asset/export-asset/export-asset.component';
import { CreateOrEditExportAssetModelComponent } from './export-asset/create-or-edit-export-asset-model/create-or-edit-export-asset-model.component';
import { TransferAssetComponent } from './transfer-asset/transfer-asset/transfer-asset.component';
import { CreateOrEditTransferAssetComponent } from './transfer-asset/create-or-edit-transfer-asset/create-or-edit-transfer-asset.component';

@NgModule({
    imports: [
        FormsModule,
        CommonModule,
        FileUploadModule,
        ModalModule.forRoot(),
        TabsModule.forRoot(),
        TooltipModule.forRoot(),
        PopoverModule.forRoot(),
        GWebsiteRoutingModule,
        UtilsModule,
        AppCommonModule,
        TableModule,
        PaginatorModule,
        PrimeNgFileUploadModule,
        AutoCompleteModule,
        EditorModule,
        InputMaskModule
    ],
    declarations: [
       // MenuClientComponent, CreateOrEditMenuClientModalComponent,
        DemoModelComponent, CreateOrEditDemoModelModalComponent, ViewDemoModelModalComponent,
        CustomerComponent, CreateOrEditCustomerModalComponent, ViewCustomerModalComponent,
        CreateOrEditAssetModelComponent, AssetComponent,
        AssetGroupComponent, CreateOrEditAssetGroupModalComponent, ViewAssetGroupModalComponent,
        DepreciationComponent, CreateOrEditDepreciationModalComponent,
        AssetTypeComponent, CreateOrEditAssetTypeModalComponent, ViewAssetTypeModalComponent,
        FixAssetComponent,CreateOrEditFixAssetModalComponent,
        UnitComponent,CreateOrEditUnitModalComponent, ExportAssetComponent, CreateOrEditExportAssetModelComponent,
        TransferAssetComponent, CreateOrEditTransferAssetComponent,
    ],
    providers: [
        DemoModelServiceProxy,
        CustomerServiceProxy,
        AssetServiceProxy,
        AssetTypeServiceProxy,
        GroupAssetServiceProxy
    ]
})
export class GWebsiteModule { }
