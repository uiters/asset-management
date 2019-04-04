import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, from as _observableFrom, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpResponse, HttpResponseBase, HttpErrorResponse } from '@angular/common/http';

import { SwaggerException, API_BASE_URL } from '@shared/service-proxies/service-proxies';

export interface IFilter {
    fieldName: string;
    value: any;
}
export interface IPagedResultDto {
    totalCount: number | undefined;
    items: any[] | undefined;
}

@Injectable()
export class WebApiServiceProxy {

    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) private http: HttpClient,
        @Optional() @Inject(API_BASE_URL) private baseUrl?: string) {
    }

    /**
     * url được define như sau:
     * <ControllerName>/<ActionName>
     * filters: IFilter[] | null | undefined
     * sorting: string | null | undefined,
     * maxResultCount: number | null | undefined,
     * skipCount: number | null | undefined
     * return IPagedResultDto
    */
    public get(url: string, filters?: IFilter[] | null | undefined,
        sorting?: string | null | undefined,
        maxResultCount?: number | null | undefined,
        skipCount?: number | null | undefined): Observable<IPagedResultDto> {
        let options_: any = {
            observe: 'response',
            responseType: 'blob',
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            })
        };
        let url_ = `${this.baseUrl}/${url}?`;
        if (filters && filters.length) {
            filters.forEach((filter: IFilter) => {
                url_ += `${filter.fieldName}=${encodeURIComponent('' + filter.value)}&`;
            });
        }
        if (sorting !== undefined) {
            url_ += 'Sorting=' + encodeURIComponent('' + sorting) + '&';
        }
        if (maxResultCount !== undefined) {
            url_ += 'MaxResultCount=' + encodeURIComponent('' + maxResultCount) + '&';
        }
        if (skipCount !== undefined) {
            url_ += 'SkipCount=' + encodeURIComponent('' + skipCount) + '&';
        }
        url_ = url_.replace(/[?&]$/, '');

        return this.http.request('get', url_, options_).pipe(_observableMergeMap((response_: any) => {
            return this.processDataList(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processDataList(<any>response_);
                } catch (e) {
                    return <Observable<IPagedResultDto>><any>_observableThrow(e);
                }
            } else {
                return <Observable<IPagedResultDto>><any>_observableThrow(response_);
            }
        }));
    }

    /**
     * Lấy dữ liệu entity theo id và dữ liệu cho combobox
     * @param url url được define như sau: <ControllerName>/<ActionName>
     * @param id Id của dto cần get thông tin
     */
    public getForEdit(url: string, id: number | null | undefined): Observable<any> {
        let options_: any = {
            observe: 'response',
            responseType: 'blob',
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            })
        };
        let url_ = `${this.baseUrl}/${url}?`;
        if (id !== undefined) {
            url_ += 'Id=' + encodeURIComponent('' + id);
        }

        return this.http.request('get', url_, options_).pipe(_observableMergeMap((response_: any) => {
            return this.processData(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processData(<any>response_);
                } catch (e) {
                    return <Observable<IPagedResultDto>><any>_observableThrow(e);
                }
            } else {
                return <Observable<IPagedResultDto>><any>_observableThrow(response_);
            }
        }));
    }

    public post(url: string, input: any | null | undefined): Observable<any> {
        let url_ = `${this.baseUrl}/${url}`;
        url_ = url_.replace(/[?&]$/, '');

        const content_ = JSON.stringify(input);
        let options_: any = {
            body: content_,
            observe: 'response',
            responseType: 'blob',
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };

        return this.http.request('post', url_, options_).pipe(_observableMergeMap((response_: any) => {
            return this.processData(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processData(<any>response_);
                } catch (e) {
                    return <Observable<any>><any>_observableThrow(e);
                }
            } else {
                return <Observable<any>><any>_observableThrow(response_);
            }
        }));
    }

    public put(url: string, input: any): Observable<any> {
        let url_ = `${this.baseUrl}/${url}`;
        url_ = url_.replace(/[?&]$/, '');

        const content_ = JSON.stringify(input);
        let options_: any = {
            body: content_,
            observe: 'response',
            responseType: 'blob',
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };

        return this.http.request('put', url_, options_).pipe(_observableMergeMap((response_: any) => {
            return this.processData(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processData(<any>response_);
                } catch (e) {
                    return <Observable<any>><any>_observableThrow(e);
                }
            } else {
                return <Observable<any>><any>_observableThrow(response_);
            }
        }));
    }

    public patch(url: string, input: any): Observable<any> {
        let url_ = `${this.baseUrl}/${url}`;
        url_ = url_.replace(/[?&]$/, '');

        const content_ = JSON.stringify(input);
        let options_: any = {
            body: content_,
            observe: 'response',
            responseType: 'blob',
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };

        return this.http.request('patch', url_, options_).pipe(_observableMergeMap((response_: any) => {
            return this.processData(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processData(<any>response_);
                } catch (e) {
                    return <Observable<any>><any>_observableThrow(e);
                }
            } else {
                return <Observable<any>><any>_observableThrow(response_);
            }
        }));
    }

    public delete(url: string, id: number | null | undefined): Observable<void> {
        let url_ = `${this.baseUrl}/${url}`;
        if (id !== undefined) {
            url_ += 'Id=' + encodeURIComponent('' + id) + '&';
        }
        url_ = url_.replace(/[?&]$/, '');

        let options_: any = {
            observe: 'response',
            responseType: 'blob',
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };

        return this.http.request('delete', url_, options_).pipe(_observableMergeMap((response_: any) => {
            return this.processDataForDelete(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processDataForDelete(<any>response_);
                } catch (e) {
                    return <Observable<void>><any>_observableThrow(e);
                }
            } else {
                return <Observable<void>><any>_observableThrow(response_);
            }
        }));
    }

    /**
     * Xử lý data khi get data list
     */
    protected processDataList(response: HttpResponseBase): Observable<IPagedResultDto> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
                (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {};
        if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); } }
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
                let result200: any = null;
                let resultData200 = _responseText === '' ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = resultData200 ? { totalCount: resultData200['totalCount'], items: resultData200['items'] } : {};
                return _observableOf(<IPagedResultDto>result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
                return throwException('An unexpected server error occurred.', status, _responseText, _headers);
            }));
        }
        return _observableOf(<any>null);
    }

    /**
     * Xử lý data khi sử dụng các methods Post, Put, Patch
    */
    protected processData(response: HttpResponseBase): Observable<any> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === '' ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 ? resultData200 : {};
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException('An unexpected server error occurred.', status, _responseText, _headers);
            }));
        }
        return _observableOf<any>(<any>null);
    }

    /**
     * Xử lý data khi sử dụng method Delete
     */
    protected processDataForDelete(response: HttpResponseBase): Observable<void> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return _observableOf<void>(<any>null);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException('An unexpected server error occurred.', status, _responseText, _headers);
            }));
        }
        return _observableOf<void>(<any>null);
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    // tslint:disable-next-line:curly
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    // tslint:disable-next-line:curly
    else
        return _observableThrow(new SwaggerException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next('');
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = function () {
                observer.next(this.result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}
