import { State } from "./state";

export interface City {
    cityCode: string;
    cityName: string;
    stateCode: string;
    latitude: string;
    longitude: string;
    state: State;
    creationDate: Date;
    createdBy: string;
    modificationDate: Date;
    modifiedBy: string;
    rowStatus: string;
}