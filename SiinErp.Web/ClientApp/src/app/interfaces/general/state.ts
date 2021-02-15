import { Country } from "./country";

export interface State {
    stateCode: string;
    stateName: string;
    countryCode: string;
    latitude: string;
    longitude: string;
    country: Country;
    creationDate: Date;
    createdBy: string;
    modificationDate: Date;
    modifiedBy: string;
    rowStatus: string;
}