import { Injectable } from "@angular/core";

@Injectable()
export class ApiRoutingService {

    private rootPrefix: string;
    routerPath = '';

    //Реализовать интерцептор для замены базового URL при ображении к API

    getFullRouterPath(endpoint: string): string {
        console.log(this.rootPrefix);
        console.log(this.routerPath);
        console.log(endpoint);

        return this.rootPrefix + this.routerPath + endpoint;
    }
}