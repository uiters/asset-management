import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class MenuClientDto {
    id: number;
    name: string;
    unitCode:string;
    unitName:string;
    user:string;
    IsDeleted: boolean;
    Status: boolean;   
}

export class GetMenuClientOutput {
    menuClient: MenuClientDto;
    menuClients: ComboboxItemDto[];
}
