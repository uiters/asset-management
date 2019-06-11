import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';
export class MenuClientDto {
    id: number;
    name: string;
    assetCode: string;
    dayBeginFix: moment.Moment | undefined;
    dayDoneFixed: moment.Moment | undefined;
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
