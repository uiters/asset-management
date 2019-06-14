import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { MenuClientComponent as DepreciationComponent } from '@app/gwebsite/depreciation/depreciation.component';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CustomerComponent } from './customer/customer.component';
import { AssetGroupComponent } from './asset-group/asset-group.component';
import { AssetComponent } from './asset/asset/asset.component';
import { AssetTypeComponent } from './asset-type/asset-type.component';
import { FixAssetComponent } from './fix-asset/fixasset.component';
import { UnitComponent } from './unit/unit.component';
import { EvictionAssetComponent } from './eviction-asset/eviction-asset.component';
import { LiquidationAssetComponent } from './liquidation-asset/liquidation-asset.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    {
                        path: 'depreciation',
                        component: DepreciationComponent
                        //data: { permission: 'Pages.Administration.Depreciation' }
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset',
                        component: AssetComponent,
                        data: { permission: 'Pages.Administration.Asset' }
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-group',
                        component: AssetGroupComponent,
                        data: { permission: 'Pages.Administration.GroupAsset' }
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-type',
                        component: AssetTypeComponent,
                        data: { permission: 'Pages.Administration.AssetType' }
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'fix-asset',
                        component: FixAssetComponent
                        //data: { permission: 'Pages.Administration.AssetType' }
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'unit',
                        component: UnitComponent
                        //data: { permission: 'Pages.Administration.AssetType' }
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'eviction-asset',
                        component: EvictionAssetComponent,
                        data: {
                            permission: 'Pages.Administration.EvictionAsset'
                        }
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'liquidation-asset',
                        component: LiquidationAssetComponent,
                        data: {
                            permission: 'Pages.Administration.LiquidationAsset'
                        }
                    }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class GWebsiteRoutingModule {}
