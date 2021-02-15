import { Component, Inject } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SelectValue, Constants } from 'src/app/interfaces/common/constants';
import { Country } from 'src/app/interfaces/general/country';
import { State } from 'src/app/interfaces/general/state';
import { SnackBarService } from 'src/app/services/common/snack-bar.service';
import { TranslateService } from 'src/app/services/common/translate.service';
import { CountryService } from 'src/app/services/general/country.service';
import { StateService } from 'src/app/services/general/state.service';

@Component({
  selector: 'app-state-dialog',
  templateUrl: './state-dialog.component.html',
  styleUrls: ['./state-dialog.component.scss']
})
export class StateDialogComponent {
  statuses: SelectValue[];
  countries: Country[];
  /**
   * Form builder
   */
  mainForm: FormGroup = this.fb.group({
    stateCode: [null, Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(10)])],
    stateName: [null, Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(150)])],
    countryCode: [null, Validators.required],
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
   * @param mainService StateService service injection
   * @param countryService CountryService service injection
   * @param dialogRef MatDialogRef class injection
   * @param data Data that is received as a parameter
   */
  constructor(
    private fb: FormBuilder,
    private _snk: SnackBarService,
    private _lang: TranslateService,
    private mainService: StateService,
    private countryService: CountryService,
    public dialogRef: MatDialogRef<StateDialogComponent>,
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
        this.mainForm.patchValue({
          stateCode: this.data.data.stateCode,
          stateName: this.data.data.stateName,
          countryCode: this.data.data.countryCode,
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
    const obj: State = {
      stateCode: this.mainForm.value.stateCode,
      stateName: this.mainForm.value.stateName,
      countryCode: this.mainForm.value.countryCode,
      latitude: this.mainForm.value.latitude,
      longitude: this.mainForm.value.longitude,
      country: null,
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
  post(obj: State): void {
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
  put(id: string, obj: State): void {
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
}