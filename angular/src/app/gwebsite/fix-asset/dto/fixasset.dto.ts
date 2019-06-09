import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class MenuClientDto {
    id: number;
    name: string;
    assetCode: string;
    dayBeginFix: Date;
    dayDoneFixed: Date;
    cost: number;
    proposer: string;
    curator: string;
    content: string;
    IsDeleted: boolean;
    Status: boolean;   
}

export class GetMenuClientOutput {
    menuClient: MenuClientDto;
    menuClients: ComboboxItemDto[];
}
