import { TestBed, inject } from '@angular/core/testing';

import { TaskTimeService } from './task-time.service';

describe('TaskTimeService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TaskTimeService]
    });
  });

  it('should be created', inject([TaskTimeService], (service: TaskTimeService) => {
    expect(service).toBeTruthy();
  }));
});
