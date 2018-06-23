import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskTimeComponent } from './task-time.component';

describe('TaskTimeComponent', () => {
  let component: TaskTimeComponent;
  let fixture: ComponentFixture<TaskTimeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaskTimeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskTimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
