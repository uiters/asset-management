import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class AssetTypeDto {
    index?: number;
    id: number;
    assetTypeCode: string;
    assetTypeName: string;
    isReadonly: boolean;
}

export class GetAssetTypeOutput {
    assetType: AssetTypeDto;
    assetTypes: ComboboxItemDto[];
}
