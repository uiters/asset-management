import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class AssetGroupDto {
    id: number;
    groupAssetCode : string;
    groupAssetName: string;
    parentGroupAssetCode: string;
    depreciationMonths: number;
    depreciationRateByYear: number;
    assetTypeCode : string;
    assetAcount: string;
    depreciationAccount: string;
    costsAccount: string;
    incomeAccount: string;
    liquidationCostAccount: string;
}

export class GetAssetGroupOutput {
    assetGroup: AssetGroupDto;
    assetGroups: ComboboxItemDto[];
}
