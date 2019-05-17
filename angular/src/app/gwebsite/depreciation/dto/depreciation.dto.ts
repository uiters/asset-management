import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class MenuClientDto {
    id: number;
    depreciationCode: string;
    name: string;
    assetCode: string;
    dayBeginCalculateDepreciation: Date;
    parentId: number | null;
    depreciationMonths: number;
    depreciatedValue: number;
    depreciationRateByYear: number;
    remainingValue: number;
    IsDeleted: boolean;
    Status: boolean;   
}

export class GetMenuClientOutput {
    menuClient: MenuClientDto;
    menuClients: ComboboxItemDto[];
}
