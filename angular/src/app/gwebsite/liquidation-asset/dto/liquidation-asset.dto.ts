import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class LiquidationAssetDto {
    index?: number;
    id: number;
    liquidationDate: Date;
    assetCode: string;
    assetName: string;
    unit: string;
    liquidationForm: string;
    liquidationCost: number;
    note: string;
    isReadonly: boolean;
}

export class GetLiquidationAssetOutput {
    liquidationAsset: LiquidationAssetDto;
    liquidationAssets: ComboboxItemDto[];
}
