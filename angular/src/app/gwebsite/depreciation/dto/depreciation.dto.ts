import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class MenuClientDto {
    id: number;
    DepreciationCode: string;
    Name: string;
    AssetCode: string;
    DayBeginCalculateDepreciation: Date;
    parentId: number | null;
    DepreciationMonths: Number;
    DepreciatedValue: Float32Array;
    DepreciationRateByYear: Float32Array;
    RemainingValue: Float32Array;
    IsDeleted: boolean;
    Status: boolean;   
}

export class GetMenuClientOutput {
    menuClient: MenuClientDto;
    menuClients: ComboboxItemDto[];
}
