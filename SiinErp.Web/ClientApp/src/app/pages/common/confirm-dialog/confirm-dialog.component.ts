import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ConfirmDialogModel } from 'src/app/interfaces/common/confirm-dialog-model';

@Component({
  selector: 'app-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrls: ['./confirm-dialog.component.scss']
})
export class ConfirmDialogComponent {

  /**
   * Component title attribute
   */
  title: string;
  /**
   * Component message attribute
   */
  message: string;

  /**
   * Component constructor
   * @param dialogRef MatDialogRef class injection
   * @param data Data that is received as a parameter
   */
  constructor(
    public dialogRef: MatDialogRef<ConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ConfirmDialogModel) {
    // Update view with given values
    this.title = data.title;
    this.message = data.message;
  }

  /**
   * Method that confirms the action to the parent
   */
  onConfirm(): void {
    // Close the dialog, return true
    this.dialogRef.close(true);
  }

  /**
   * Method that denies the action to the father
   */
  onDismiss(): void {
    // Close the dialog, return false
    this.dialogRef.close(false);
  }
}