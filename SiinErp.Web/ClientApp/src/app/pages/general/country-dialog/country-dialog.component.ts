import { Component, Inject } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SelectValue, Constants } from 'src/app/interfaces/common/constants';
import { Country } from 'src/app/interfaces/general/country';
import { SnackBarService } from 'src/app/services/common/snack-bar.service';
import { TranslateService } from 'src/app/services/common/translate.service';
import { CountryService } from 'src/app/services/general/country.service';

@Component({
  selector: 'app-country-dialog',
  templateUrl: './country-dialog.component.html',
  styleUrls: ['./country-dialog.component.scss']
})
export class CountryDialogComponent {
  statuses: SelectValue[];
  /**
   * Form builder
   */
  mainForm: FormGroup = this.fb.group({
    countryCode: [null, Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(3)])],
    countryName: [null, Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(150)])],
    alfa2Code: [null, Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(2)])],
    numberCode: [null, Validators.compose([Validators.maxLength(3)])],
    internetCode: [null, Validators.compose([Validators.maxLength(10)])],
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
   * @param mainService CountryService service injection
   * @param dialogRef MatDialogRef class injection
   * @param data Data that is received as a parameter
   */
  constructor(
    private fb: FormBuilder,
    private _snk: SnackBarService,
    private _lang: TranslateService,
    private mainService: CountryService,
    public dialogRef: MatDialogRef<CountryDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.statuses = Constants.ROW_STATUS;
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
          countryCode: this.data.data.countryCode,
          countryName: this.data.data.countryName,
          alfa2Code: this.data.data.alfa2Code,
          numberCode: this.data.data.numberCode,
          internetCode: this.data.data.internetCode,
          rowStatus: this.data.data.rowStatus
        });
      }
    }
  }

  /**
   * Method for persist or merge data
   */
  onSubmit(): void {
    const obj: Country = {
      countryCode: this.mainForm.value.countryCode,
      countryName: this.mainForm.value.countryName,
      alfa2Code: this.mainForm.value.alfa2Code,
      numberCode: this.mainForm.value.numberCode,
      internetCode: this.mainForm.value.internetCode,
      creationDate: this.create ? new Date() : this.data.data.creationDate,
      createdBy: this.create ? 'SYSTEM' : this.data.data.createdBy,
      modificationDate: new Date(),
      modifiedBy: 'SYSTEM',
      rowStatus: this.mainForm.value.rowStatus
    };
    if (this.create) {
      this.post(obj);
    } else {
      this.put(obj.countryCode, obj);
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
  post(obj: Country): void {
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
  put(id: string, obj: Country): void {
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
}