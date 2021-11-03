import axios from "axios"
import React, { useEffect, useState } from "react";
import Calendar from './calendar';
import moment from "moment";

const Glasses = () => {
  const [startDate, setStartDate] = useState(new Date());
  const [numberOfGlasses, setNumberofGlasses] = useState('...');

  useEffect(() => {
    //The date is always a date object, so we'll parse it with moments
    const selectedDate = moment(startDate).format('YYYY-MM-DD');

    axios.get("https://localhost:44398/water?date=" + selectedDate)
    .then((response) => {
      const data = response.data;
      setNumberofGlasses(data.numberOfGlasses);
    });
  }, [startDate])

  const handleStatusChange = (startDate) => {
    setStartDate(startDate);
  }

  return (
        <div>
          On <br />
          <Calendar 
            startDate={startDate}
            onChange={startDate => handleStatusChange(startDate)}
          />
          { numberOfGlasses === 0 ? 
            <div>I didn't drink water :(</div> : 
            <div>I had { numberOfGlasses } glases of water</div>
          }
        </div>
    )
  }

export default Glasses