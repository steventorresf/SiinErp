import { Injectable } from '@angular/core';
import { NzNotificationService } from 'ng-zorro-antd/notification';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private notification: NzNotificationService) { }

  private create(type: string, title: string, message: string): void {
    this.notification.create(type, title, message);
  }

  error(title: string, message: string): void {
    this.create('error', title, message);
  }

  info(title: string, message: string): void {
    this.create('info', title, message);
  }

  success(title: string, message: string): void {
    this.create('success', title, message);
  }

  warning(title: string, message: string): void {
    this.create('warning', title, message);
  }

  successCreation(): void {
    this.success('Creación', 'Registro creado exitosamente!');
  }

  successUpdate(): void {
    this.success('Edición', 'Registro actualizado exitosamente!');
  }
}