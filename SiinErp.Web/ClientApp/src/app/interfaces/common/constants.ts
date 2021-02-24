import { HttpHeaders } from "@angular/common/http";
import { SelectValue } from "./select-value";

export class Constants {
    public static APP_LANG_DEFAULT: string = 'es';

    //public static API_ENDPOINT: string = 'https://localhost:5001/general/api/pais';
    public static API_ENDPOINT: string = '/';

    public static HTTP_OPTIONS: any = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    public static ROW_STATUS: SelectValue[] = [
        { value: 'A', text: 'Activo' },
        { value: 'I', text: 'Inactivo' }
    ];
}