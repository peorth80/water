import React from "react";
import DayPickerInput from 'react-day-picker/DayPickerInput';
import 'react-day-picker/lib/style.css';

const Calendar = (props) => {
  return (
    <DayPickerInput value={props.startDate} onDayChange={day => props.onChange(day)} />
  );
};

export default Calendar;