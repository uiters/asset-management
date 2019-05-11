import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class AssetTypeDto {
    id: number;
    assetTypeCode: string;
    assetTypeName: string;
}

export class GetAssetTypeOutput {
    assetType: AssetTypeDto;
    assetTypes: ComboboxItemDto[];
}
