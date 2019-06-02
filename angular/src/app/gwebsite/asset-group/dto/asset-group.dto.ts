import { ComboboxItemDto } from "@shared/service-proxies/service-proxies";
import { AssetTypeDto } from "@app/gwebsite/asset-type/dto/asset-type.dto";

export class AssetGroupDto {
    id: number;
    index?: number;
    groupAssetCode: string;
    groupAssetName: string;
    parentGroupAssetCode?: string;
    depreciationMonths: number;
    depreciationRateByYear: number;
    assetTypeCode: string;
    assetType: AssetTypeDto | undefined;
    assetAcount: string;
    depreciationAccount: string;
    costsAccount: string;
    incomeAccount: string;
    liquidationCostAccount: string;
    isReadonly: boolean;
}

export class GetAssetGroupOutput {
    assetGroup: AssetGroupDto;
    assetGroups: ComboboxItemDto[];
}
