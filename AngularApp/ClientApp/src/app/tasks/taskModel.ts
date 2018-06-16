import { TaskStatusModel } from "./taskStatusModel";

export interface TaskModel {
  taskModelId: number;
  title: string;
  body: string;
  createdDate: Date;
  startDate: Date;
  endDate: Date;
  userId: number;
  taskStatusModelId: number;
  taskStatusModels: TaskStatusModel[];
}
