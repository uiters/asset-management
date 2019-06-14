import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class EvictionAssetDto {
    index?: number;
    id: number;
    evictionDate: Date | string;
    assetCode: string;
    assetName: string;
    reason: string;
    content: string;
    isReadonly: boolean;
}

export class GetEvictionAssetOutput {
    evictionAsset: EvictionAssetDto;
    evictionAssets: ComboboxItemDto[];
}
