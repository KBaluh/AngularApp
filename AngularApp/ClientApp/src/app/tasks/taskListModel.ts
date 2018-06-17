import { TaskModel } from "./taskModel";

export interface TaskListModel extends TaskModel {
  taskStatusModelName: string;
}
