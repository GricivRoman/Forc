export class MainApiRoutingService {
    
    private rootPrefix = 'https://localhost:7000/';
    routerPath = '';
    readonly fullRouterPath: string;
    
    constructor() {
        this.fullRouterPath = this.rootPrefix + this.routerPath;
    }
}