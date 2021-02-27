#region Imports

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace BusinessModel {

    public abstract class DbObject {

        #region Fields

        protected ulong id;
        protected string code;
        protected DateTime creation;

        #endregion
        
        #region Constructor

        protected DbObject() {
            this.creation = DateTime.Now;
        }

        protected DbObject(ulong id) {
            this.id = id;
            this.creation = DateTime.Now;
        } 

        #endregion

        #region Properties

        public ulong Id {
            get { return id; }
            set { id = value; }
        }

        public string Code   {
            get { return code; }
            set { code = value; }
        }
        public DateTime Creation  {
            get { return creation; }
            set { creation = value; }
        }

        #endregion

        #region Public Methods

        public virtual Broker GetBroker() { return null; }
 
        public void SaveUpdate() { GetBroker().SaveUpdate(this); }
        public void Read() { GetBroker().Read(this); }
        public void Read(string fieldName, ulong id) { GetBroker().Read(this, fieldName, id); }
        public void Read(string condition) { GetBroker().Read(this, condition); }
        public void Delete() { GetBroker().Delete(this); }
        public void Delete(string condition) { GetBroker().Delete(this, condition); }
        public void ReadMany(List<DbObject> objs, string condition) { GetBroker().ReadMany(objs, condition); }
     
        #endregion

        #region ToString override

        public override string ToString()  {
            return id + " " + code + " " + creation;
        }

        #endregion

    }
}

    