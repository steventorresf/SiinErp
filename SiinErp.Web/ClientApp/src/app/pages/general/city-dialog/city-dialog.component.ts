import { Component, Inject } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SelectValue, Constants } from 'src/app/interfaces/common/constants';
import { Country } from 'src/app/interfaces/general/country';
import { State } from 'src/app/interfaces/general/state';
import { City } from 'src/app/interfaces/general/city';
import { SnackBarService } from 'src/app/services/common/snack-bar.service';
import { TranslateService } from 'src/app/services/common/translate.service';
import { CountryService } from 'src/app/services/general/country.service';
import { StateService } from 'src/app/services/general/state.service';
import { CityService } from 'src/app/services/general/city.service';

@Component({
  selector: 'app-city-dialog',
  templateUrl: './city-dialog.component.html',
  styleUrls: ['./city-dialog.component.scss']
})
export class CityDialogComponent {
  statuses: SelectValue[];
  countries: Country[];
  states: State[];
  /**
   * Form builder
   */
  mainForm: FormGroup = this.fb.group({
    cityCode: [null, Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(10)])],
    cityName: [null, Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(150)])],
    countryCode: [null, Validators.required],
    stateCode: [null, Validators.required],
    latitude: [null, Validators.compose([Validators.maxLength(20)])],
    longitude: [null, Validators.compose([Validators.maxLength(20)])],
    rowStatus: [null, Validators.required],
  });
  /**
   * Variable that allows determining if the form is for editing or creating
   */
  create: boolean = false;
  /**
   * Component constructor
   * @param fb FormBuilder class injection
   * @param _snk SnackBarService service injection
   * @param _lang TranslateService service injection
   * @param mainService CityService service injection
   * @param countryService CountryService service injection
   * @param stateService StateService service injection
   * @param dialogRef MatDialogRef class injection
   * @param data Data that is received as a parameter
   */
  constructor(
    private fb: FormBuilder,
    private _snk: SnackBarService,
    private _lang: TranslateService,
    private mainService: CityService,
    private countryService: CountryService,
    private stateService: StateService,
    public dialogRef: MatDialogRef<CityDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.statuses = Constants.ROW_STATUS;
    this.getAllCountries();
    if (this.data !== null) {
      if (this.data.hasOwnProperty('create')) {
        this.create = this.data.create;
      }
      if (this.create) {
        this.mainForm.patchValue({
          rowStatus: 'A'
        });
      }
      if (this.data.hasOwnProperty('data')) {
        this.getStatesByCountryCode(this.data.data.state.countryCode);
        this.mainForm.patchValue({
          cityCode: this.data.data.cityCode,
          cityName: this.data.data.cityName,
          stateCode: this.data.data.stateCode,
          countryCode: this.data.data.state.countryCode,
          latitude: this.data.data.latitude,
          longitude: this.data.data.longitude,
          rowStatus: this.data.data.rowStatus
        });
      }
    }
  }

  /**
   * Method for persist or merge data
   */
  onSubmit(): void {
    const obj: City = {
      cityCode: this.mainForm.value.cityCode,
      cityName: this.mainForm.value.cityName,
      stateCode: this.mainForm.value.stateCode,
      latitude: this.mainForm.value.latitude,
      longitude: this.mainForm.value.longitude,
      state: null,
      creationDate: this.create ? new Date() : this.data.data.creationDate,
      createdBy: this.create ? 'SYSTEM' : this.data.data.createdBy,
      modificationDate: new Date(),
      modifiedBy: 'SYSTEM',
      rowStatus: this.mainForm.value.rowStatus
    };
    if (this.create) {
      this.post(obj);
    } else {
      this.put(obj.stateCode, obj);
    }
  }

  /**
   * Method for close the dialog window
   */
  close(): void {
    this.dialogRef.close();
  }

  /**
   * Method invoking the persistence service
   * @param obj Object to persist
   */
  post(obj: City): void {
    this.mainService.add(obj)
      .subscribe((res: any) => {
        if (res !== undefined && res !== null && res.hasOwnProperty('ownHandle')) {
          this._snk.show(this._lang.data[res.message]);
          console.error(res.object);
        } else {
          this.mainForm.reset();
          this._snk.show(this._lang.data[Constants.MESSAGE_ROW_CREATED]);
          this.dialogRef.close();
        }
      }, err => {
        this._snk.show(this._lang.data[Constants.MESSAGE_ROW_ERROR]);
        console.error(err);
      });
  }

  /**
   * Method invoking the merge service
   * @param id Object Key
   * @param obj Object to update
   */
  put(id: string, obj: City): void {
    this.mainService.update(id, obj)
      .subscribe((res: any) => {
        if (res !== undefined && res !== null && res.hasOwnProperty('ownHandle')) {
          this._snk.show(this._lang.data[res.message]);
          console.error(res.object);
        } else {
          this.mainForm.reset();
          this._snk.show(this._lang.data[Constants.MESSAGE_ROW_UPDATED]);
          this.dialogRef.close();
        }
      }, err => {
        this._snk.show(this._lang.data[Constants.MESSAGE_ROW_ERROR]);
        console.error(err);
      });
  }

  /**
   * Method get all the countries
   */
  getAllCountries(): void {
    this.countryService.getAll()
      .subscribe((res: any) => {
        this.countries = res;
      }, err => {
        console.error(err);
      });
  }

  /**
   * Method get all the states by Country Code when selector change
   * @param event Selector event value
   */
  changeCountryCode(event: any): void {
    if (event.isUserInput) {
      this.getStatesByCountryCode(event.source.value);
    }
  }

  /**
   * Method get all the states by Country Code
   */
  getStatesByCountryCode(id: string): void {
    this.stateService.getByCountry(id)
      .subscribe((res: any) => {
        this.states = res;
      }, err => {
        console.error(err);
      });
  }
}