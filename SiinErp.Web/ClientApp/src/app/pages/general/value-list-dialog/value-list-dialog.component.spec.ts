import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ValueListDialogComponent } from './value-list-dialog.component';

describe('ValueListDialogComponent', () => {
  let component: ValueListDialogComponent;
  let fixture: ComponentFixture<ValueListDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ValueListDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ValueListDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
