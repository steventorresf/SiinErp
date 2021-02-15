import { Component, Inject } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SelectValue, Constants } from 'src/app/interfaces/common/constants';
import { ValueList } from 'src/app/interfaces/general/value-list';
import { SnackBarService } from 'src/app/services/common/snack-bar.service';
import { TranslateService } from 'src/app/services/common/translate.service';
import { ValueListService } from 'src/app/services/general/value-list.service';

@Component({
  selector: 'app-value-list-dialog',
  templateUrl: './value-list-dialog.component.html',
  styleUrls: ['./value-list-dialog.component.scss']
})
export class ValueListDialogComponent {
  statuses: SelectValue[];
  /**
   * Form builder
   */
  mainForm: FormGroup = this.fb.group({
    valueListCode: [null, Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(50)])],
    valueListCategory: [null, Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(20)])],
    listOrder: [null, Validators.required],
    shortDescription: [null, Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(45)])],
    longDescription: [null, Validators.compose([Validators.maxLength(90)])],
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
   * @param mainService ValueListService service injection
   * @param dialogRef MatDialogRef class injection
   * @param data Data that is received as a parameter
   */
  constructor(
    private fb: FormBuilder,
    private _snk: SnackBarService,
    private _lang: TranslateService,
    private mainService: ValueListService,
    public dialogRef: MatDialogRef<ValueListDialogComponent>,
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
          valueListCode: this.data.data.valueListCode,
          valueListCategory: this.data.data.valueListCategory,
          listOrder: this.data.data.listOrder,
          shortDescription: this.data.data.shortDescription,
          longDescription: this.data.data.longDescription,
          rowStatus: this.data.data.rowStatus
        });
      }
    }
  }

  /**
   * Method for persist or merge data
   */
  onSubmit(): void {
    const obj: ValueList = {
      valueListCode: this.mainForm.value.valueListCode,
      valueListCategory: this.mainForm.value.valueListCategory,
      listOrder: this.mainForm.value.listOrder,
      shortDescription: this.mainForm.value.shortDescription,
      longDescription: this.mainForm.value.longDescription,
      creationDate: this.create ? new Date() : this.data.data.creationDate,
      createdBy: this.create ? 'SYSTEM' : this.data.data.createdBy,
      modificationDate: new Date(),
      modifiedBy: 'SYSTEM',
      rowStatus: this.mainForm.value.rowStatus
    };
    if (this.create) {
      this.post(obj);
    } else {
      this.put(obj.valueListCode, obj);
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
  post(obj: ValueList): void {
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
  put(id: string, obj: ValueList): void {
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