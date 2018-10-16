using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DDS;
using DDS.OpenSplice;
using DDS.OpenSplice.CustomMarshalers;

namespace EDAQ
{
    #region CommandDataReader
    public class CommandDataReader : DDS.OpenSplice.FooDataReader<Command, CommandMarshaler>, 
                                         ICommandDataReader
    {
        public CommandDataReader(DatabaseMarshaler marshaler)
            : base(marshaler) { }

        public ReturnCode Read(
            ref Command[] dataValues,
            ref SampleInfo[] sampleInfos)
        {
            return Read(ref dataValues, ref sampleInfos, Length.Unlimited);
        }

        public ReturnCode Read(
            ref Command[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples)
        {
            return Read(ref dataValues, ref sampleInfos, maxSamples, SampleStateKind.Any,
                ViewStateKind.Any, InstanceStateKind.Any);
        }

        public ReturnCode Read(
            ref Command[] dataValues,
            ref SampleInfo[] sampleInfos,
            SampleStateKind sampleStates,
            ViewStateKind viewStates,
            InstanceStateKind instanceStates)
        {
            return Read(ref dataValues, ref sampleInfos, Length.Unlimited, sampleStates,
                viewStates, instanceStates);
        }

        public override ReturnCode Read(
                ref Command[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.Read(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode Take(
            ref Command[] dataValues,
            ref SampleInfo[] sampleInfos)
        {
            return Take(ref dataValues, ref sampleInfos, Length.Unlimited);
        }

        public ReturnCode Take(
            ref Command[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples)
        {
            return Take(ref dataValues, ref sampleInfos, maxSamples, SampleStateKind.Any,
                ViewStateKind.Any, InstanceStateKind.Any);
        }

        public ReturnCode Take(
            ref Command[] dataValues,
            ref SampleInfo[] sampleInfos,
            SampleStateKind sampleStates,
            ViewStateKind viewStates,
            InstanceStateKind instanceStates)
        {
            return Take(ref dataValues, ref sampleInfos, Length.Unlimited, sampleStates,
                viewStates, instanceStates);
        }

        public override ReturnCode Take(
                ref Command[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.Take(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode ReadWithCondition(
            ref Command[] dataValues,
            ref SampleInfo[] sampleInfos,
            IReadCondition readCondition)
        {
            return ReadWithCondition(ref dataValues, ref sampleInfos,
                Length.Unlimited, readCondition);
        }

        public override ReturnCode ReadWithCondition(
                ref Command[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.ReadWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        readCondition);
            return result;
        }

        public ReturnCode TakeWithCondition(
            ref Command[] dataValues,
            ref SampleInfo[] sampleInfos,
            IReadCondition readCondition)
        {
            return TakeWithCondition(ref dataValues, ref sampleInfos,
                Length.Unlimited, readCondition);
        }

        public override ReturnCode TakeWithCondition(
                ref Command[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.TakeWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        readCondition);
            return result;
        }

        public override ReturnCode ReadNextSample(
                ref Command dataValue,
                ref SampleInfo sampleInfo)
        {
            ReturnCode result =
                base.ReadNextSample(
                        ref dataValue,
                        ref sampleInfo);
            return result;
        }

        public override ReturnCode TakeNextSample(
                ref Command dataValue,
                ref SampleInfo sampleInfo)
        {
            ReturnCode result =
                base.TakeNextSample(
                        ref dataValue,
                        ref sampleInfo);
            return result;
        }

        public ReturnCode ReadInstance(
            ref Command[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return ReadInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode ReadInstance(
            ref Command[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return ReadInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode ReadInstance(
                ref Command[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.ReadInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode TakeInstance(
            ref Command[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return TakeInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode TakeInstance(
            ref Command[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return TakeInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode TakeInstance(
                ref Command[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.TakeInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode ReadNextInstance(
            ref Command[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return ReadNextInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode ReadNextInstance(
            ref Command[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return ReadNextInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode ReadNextInstance(
                ref Command[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.ReadNextInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode TakeNextInstance(
            ref Command[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return TakeNextInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode TakeNextInstance(
            ref Command[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return TakeNextInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode TakeNextInstance(
                ref Command[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.TakeNextInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode ReadNextInstanceWithCondition(
                ref Command[] dataValues,
                ref SampleInfo[] sampleInfos,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            return ReadNextInstanceWithCondition(
                ref dataValues,
                ref sampleInfos,
                Length.Unlimited,
                instanceHandle,
                readCondition);
        }

        public override ReturnCode ReadNextInstanceWithCondition(
                ref Command[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.ReadNextInstanceWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        readCondition);
            return result;
        }

        public ReturnCode TakeNextInstanceWithCondition(
                ref Command[] dataValues,
                ref SampleInfo[] sampleInfos,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            return TakeNextInstanceWithCondition(
                ref dataValues,
                ref sampleInfos,
                Length.Unlimited,
                instanceHandle,
                readCondition);
        }

        public override ReturnCode TakeNextInstanceWithCondition(
                ref Command[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.TakeNextInstanceWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        readCondition);

            return result;
        }

        public override ReturnCode ReturnLoan(
                ref Command[] dataValues,
                ref SampleInfo[] sampleInfos)
        {
            ReturnCode result =
                base.ReturnLoan(
                        ref dataValues,
                        ref sampleInfos);

            return result;
        }

        public override ReturnCode GetKeyValue(
                ref Command key,
                InstanceHandle handle)
        {
            ReturnCode result = base.GetKeyValue(
                        ref key,
                        handle);
            return result;
        }

        public override InstanceHandle LookupInstance(
                Command instance)
        {
            return
                base.LookupInstance(
                        instance);
        }

    }
    #endregion
    
    #region CommandDataWriter
    public class CommandDataWriter : DDS.OpenSplice.FooDataWriter<Command, CommandMarshaler>, 
                                         ICommandDataWriter
    {
        public CommandDataWriter(DatabaseMarshaler marshaler)
            : base(marshaler) { }

        public InstanceHandle RegisterInstance(
                Command instanceData)
        {
            return base.RegisterInstance(
                    instanceData,
                    Time.Current);
        }

        public InstanceHandle RegisterInstanceWithTimestamp(
                Command instanceData,
                Time sourceTimestamp)
        {
            return base.RegisterInstance(
                    instanceData,
                    sourceTimestamp);
        }

        public ReturnCode UnregisterInstance(
                Command instanceData,
                InstanceHandle instanceHandle)
        {
            return base.UnregisterInstance(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode UnregisterInstanceWithTimestamp(
                Command instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.UnregisterInstance(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public ReturnCode Write(Command instanceData)
        {
            return base.Write(
                    instanceData,
                    InstanceHandle.Nil,
                    Time.Current);
        }

        public ReturnCode Write(
                Command instanceData,
                InstanceHandle instanceHandle)
        {
            return base.Write(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode WriteWithTimestamp(
                Command instanceData,
                Time sourceTimestamp)
        {
            return base.Write(
                    instanceData,
                    InstanceHandle.Nil,
                    sourceTimestamp);
        }

        public ReturnCode WriteWithTimestamp(
                Command instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.Write(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public ReturnCode Dispose(
                Command instanceData,
                InstanceHandle instanceHandle)
        {
            return base.Dispose(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode DisposeWithTimestamp(
                Command instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.Dispose(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public ReturnCode WriteDispose(
                Command instanceData)
        {
            return base.WriteDispose(
                    instanceData,
                    InstanceHandle.Nil,
                    Time.Current);
        }

        public ReturnCode WriteDispose(
                Command instanceData,
                InstanceHandle instanceHandle)
        {
            return base.WriteDispose(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode WriteDisposeWithTimestamp(
                Command instanceData,
                Time sourceTimestamp)
        {
            return base.WriteDispose(
                    instanceData,
                    InstanceHandle.Nil,
                    sourceTimestamp);
        }

        public ReturnCode WriteDisposeWithTimestamp(
                Command instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.WriteDispose(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public override ReturnCode GetKeyValue(
                ref Command key,
                InstanceHandle instanceHandle)
        {
            return base.GetKeyValue(ref key, instanceHandle);
        }

        public override InstanceHandle LookupInstance(
            Command instanceData)
        {
            return base.LookupInstance(instanceData);
        }
    }
    #endregion

    #region CommandTypeSupport
    public class CommandTypeSupport : DDS.OpenSplice.TypeSupport
    {
        private static readonly string[] metaDescriptor = {"<MetaData version=\"1.0.0\"><Module name=\"EDAQ\"><Struct name=\"Command\"><Member name=\"bbg_id\"><UShort/>",
"</Member><Member name=\"daq_id\"><UShort/></Member><Member name=\"fc\"><UShort/></Member><Member name=\"msg\">",
"<String/></Member><Member name=\"start\"><Boolean/></Member></Struct></Module></MetaData>"};

        public CommandTypeSupport()
            : base(typeof(Command), metaDescriptor, "EDAQ::Command", "", "bbg_id,daq_id")
        { }


        public override ReturnCode RegisterType(IDomainParticipant participant, string typeName)
        {
            return RegisterType(participant, typeName, new CommandMarshaler());
        }

        public override DDS.OpenSplice.DataWriter CreateDataWriter(DatabaseMarshaler marshaler)
        {
            return new CommandDataWriter(marshaler);
        }

        public override DDS.OpenSplice.DataReader CreateDataReader(DatabaseMarshaler marshaler)
        {
            return new CommandDataReader(marshaler);
        }
    }
    #endregion

    #region ContinueDataDataReader
    public class ContinueDataDataReader : DDS.OpenSplice.FooDataReader<ContinueData, ContinueDataMarshaler>, 
                                         IContinueDataDataReader
    {
        public ContinueDataDataReader(DatabaseMarshaler marshaler)
            : base(marshaler) { }

        public ReturnCode Read(
            ref ContinueData[] dataValues,
            ref SampleInfo[] sampleInfos)
        {
            return Read(ref dataValues, ref sampleInfos, Length.Unlimited);
        }

        public ReturnCode Read(
            ref ContinueData[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples)
        {
            return Read(ref dataValues, ref sampleInfos, maxSamples, SampleStateKind.Any,
                ViewStateKind.Any, InstanceStateKind.Any);
        }

        public ReturnCode Read(
            ref ContinueData[] dataValues,
            ref SampleInfo[] sampleInfos,
            SampleStateKind sampleStates,
            ViewStateKind viewStates,
            InstanceStateKind instanceStates)
        {
            return Read(ref dataValues, ref sampleInfos, Length.Unlimited, sampleStates,
                viewStates, instanceStates);
        }

        public override ReturnCode Read(
                ref ContinueData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.Read(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode Take(
            ref ContinueData[] dataValues,
            ref SampleInfo[] sampleInfos)
        {
            return Take(ref dataValues, ref sampleInfos, Length.Unlimited);
        }

        public ReturnCode Take(
            ref ContinueData[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples)
        {
            return Take(ref dataValues, ref sampleInfos, maxSamples, SampleStateKind.Any,
                ViewStateKind.Any, InstanceStateKind.Any);
        }

        public ReturnCode Take(
            ref ContinueData[] dataValues,
            ref SampleInfo[] sampleInfos,
            SampleStateKind sampleStates,
            ViewStateKind viewStates,
            InstanceStateKind instanceStates)
        {
            return Take(ref dataValues, ref sampleInfos, Length.Unlimited, sampleStates,
                viewStates, instanceStates);
        }

        public override ReturnCode Take(
                ref ContinueData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.Take(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode ReadWithCondition(
            ref ContinueData[] dataValues,
            ref SampleInfo[] sampleInfos,
            IReadCondition readCondition)
        {
            return ReadWithCondition(ref dataValues, ref sampleInfos,
                Length.Unlimited, readCondition);
        }

        public override ReturnCode ReadWithCondition(
                ref ContinueData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.ReadWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        readCondition);
            return result;
        }

        public ReturnCode TakeWithCondition(
            ref ContinueData[] dataValues,
            ref SampleInfo[] sampleInfos,
            IReadCondition readCondition)
        {
            return TakeWithCondition(ref dataValues, ref sampleInfos,
                Length.Unlimited, readCondition);
        }

        public override ReturnCode TakeWithCondition(
                ref ContinueData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.TakeWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        readCondition);
            return result;
        }

        public override ReturnCode ReadNextSample(
                ref ContinueData dataValue,
                ref SampleInfo sampleInfo)
        {
            ReturnCode result =
                base.ReadNextSample(
                        ref dataValue,
                        ref sampleInfo);
            return result;
        }

        public override ReturnCode TakeNextSample(
                ref ContinueData dataValue,
                ref SampleInfo sampleInfo)
        {
            ReturnCode result =
                base.TakeNextSample(
                        ref dataValue,
                        ref sampleInfo);
            return result;
        }

        public ReturnCode ReadInstance(
            ref ContinueData[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return ReadInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode ReadInstance(
            ref ContinueData[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return ReadInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode ReadInstance(
                ref ContinueData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.ReadInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode TakeInstance(
            ref ContinueData[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return TakeInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode TakeInstance(
            ref ContinueData[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return TakeInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode TakeInstance(
                ref ContinueData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.TakeInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode ReadNextInstance(
            ref ContinueData[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return ReadNextInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode ReadNextInstance(
            ref ContinueData[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return ReadNextInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode ReadNextInstance(
                ref ContinueData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.ReadNextInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode TakeNextInstance(
            ref ContinueData[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return TakeNextInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode TakeNextInstance(
            ref ContinueData[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return TakeNextInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode TakeNextInstance(
                ref ContinueData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.TakeNextInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode ReadNextInstanceWithCondition(
                ref ContinueData[] dataValues,
                ref SampleInfo[] sampleInfos,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            return ReadNextInstanceWithCondition(
                ref dataValues,
                ref sampleInfos,
                Length.Unlimited,
                instanceHandle,
                readCondition);
        }

        public override ReturnCode ReadNextInstanceWithCondition(
                ref ContinueData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.ReadNextInstanceWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        readCondition);
            return result;
        }

        public ReturnCode TakeNextInstanceWithCondition(
                ref ContinueData[] dataValues,
                ref SampleInfo[] sampleInfos,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            return TakeNextInstanceWithCondition(
                ref dataValues,
                ref sampleInfos,
                Length.Unlimited,
                instanceHandle,
                readCondition);
        }

        public override ReturnCode TakeNextInstanceWithCondition(
                ref ContinueData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.TakeNextInstanceWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        readCondition);

            return result;
        }

        public override ReturnCode ReturnLoan(
                ref ContinueData[] dataValues,
                ref SampleInfo[] sampleInfos)
        {
            ReturnCode result =
                base.ReturnLoan(
                        ref dataValues,
                        ref sampleInfos);

            return result;
        }

        public override ReturnCode GetKeyValue(
                ref ContinueData key,
                InstanceHandle handle)
        {
            ReturnCode result = base.GetKeyValue(
                        ref key,
                        handle);
            return result;
        }

        public override InstanceHandle LookupInstance(
                ContinueData instance)
        {
            return
                base.LookupInstance(
                        instance);
        }

    }
    #endregion
    
    #region ContinueDataDataWriter
    public class ContinueDataDataWriter : DDS.OpenSplice.FooDataWriter<ContinueData, ContinueDataMarshaler>, 
                                         IContinueDataDataWriter
    {
        public ContinueDataDataWriter(DatabaseMarshaler marshaler)
            : base(marshaler) { }

        public InstanceHandle RegisterInstance(
                ContinueData instanceData)
        {
            return base.RegisterInstance(
                    instanceData,
                    Time.Current);
        }

        public InstanceHandle RegisterInstanceWithTimestamp(
                ContinueData instanceData,
                Time sourceTimestamp)
        {
            return base.RegisterInstance(
                    instanceData,
                    sourceTimestamp);
        }

        public ReturnCode UnregisterInstance(
                ContinueData instanceData,
                InstanceHandle instanceHandle)
        {
            return base.UnregisterInstance(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode UnregisterInstanceWithTimestamp(
                ContinueData instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.UnregisterInstance(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public ReturnCode Write(ContinueData instanceData)
        {
            return base.Write(
                    instanceData,
                    InstanceHandle.Nil,
                    Time.Current);
        }

        public ReturnCode Write(
                ContinueData instanceData,
                InstanceHandle instanceHandle)
        {
            return base.Write(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode WriteWithTimestamp(
                ContinueData instanceData,
                Time sourceTimestamp)
        {
            return base.Write(
                    instanceData,
                    InstanceHandle.Nil,
                    sourceTimestamp);
        }

        public ReturnCode WriteWithTimestamp(
                ContinueData instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.Write(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public ReturnCode Dispose(
                ContinueData instanceData,
                InstanceHandle instanceHandle)
        {
            return base.Dispose(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode DisposeWithTimestamp(
                ContinueData instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.Dispose(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public ReturnCode WriteDispose(
                ContinueData instanceData)
        {
            return base.WriteDispose(
                    instanceData,
                    InstanceHandle.Nil,
                    Time.Current);
        }

        public ReturnCode WriteDispose(
                ContinueData instanceData,
                InstanceHandle instanceHandle)
        {
            return base.WriteDispose(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode WriteDisposeWithTimestamp(
                ContinueData instanceData,
                Time sourceTimestamp)
        {
            return base.WriteDispose(
                    instanceData,
                    InstanceHandle.Nil,
                    sourceTimestamp);
        }

        public ReturnCode WriteDisposeWithTimestamp(
                ContinueData instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.WriteDispose(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public override ReturnCode GetKeyValue(
                ref ContinueData key,
                InstanceHandle instanceHandle)
        {
            return base.GetKeyValue(ref key, instanceHandle);
        }

        public override InstanceHandle LookupInstance(
            ContinueData instanceData)
        {
            return base.LookupInstance(instanceData);
        }
    }
    #endregion

    #region ContinueDataTypeSupport
    public class ContinueDataTypeSupport : DDS.OpenSplice.TypeSupport
    {
        private static readonly string[] metaDescriptor = {"<MetaData version=\"1.0.0\"><Module name=\"EDAQ\"><TypeDef name=\"data\"><Sequence><UShort/></Sequence>",
"</TypeDef><Struct name=\"ContinueData\"><Member name=\"bbg_id\"><UShort/></Member><Member name=\"daq_id\">",
"<UShort/></Member><Member name=\"check_count\"><UShort/></Member><Member name=\"read_count\"><ULong/>",
"</Member><Member name=\"sample_rate\"><Double/></Member><Member name=\"is_32\"><Boolean/></Member><Member name=\"payload\">",
"<Type name=\"data\"/></Member></Struct></Module></MetaData>"};

        public ContinueDataTypeSupport()
            : base(typeof(ContinueData), metaDescriptor, "EDAQ::ContinueData", "", "bbg_id,daq_id")
        { }


        public override ReturnCode RegisterType(IDomainParticipant participant, string typeName)
        {
            return RegisterType(participant, typeName, new ContinueDataMarshaler());
        }

        public override DDS.OpenSplice.DataWriter CreateDataWriter(DatabaseMarshaler marshaler)
        {
            return new ContinueDataDataWriter(marshaler);
        }

        public override DDS.OpenSplice.DataReader CreateDataReader(DatabaseMarshaler marshaler)
        {
            return new ContinueDataDataReader(marshaler);
        }
    }
    #endregion

    #region ContinueScaleDataReader
    public class ContinueScaleDataReader : DDS.OpenSplice.FooDataReader<ContinueScale, ContinueScaleMarshaler>, 
                                         IContinueScaleDataReader
    {
        public ContinueScaleDataReader(DatabaseMarshaler marshaler)
            : base(marshaler) { }

        public ReturnCode Read(
            ref ContinueScale[] dataValues,
            ref SampleInfo[] sampleInfos)
        {
            return Read(ref dataValues, ref sampleInfos, Length.Unlimited);
        }

        public ReturnCode Read(
            ref ContinueScale[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples)
        {
            return Read(ref dataValues, ref sampleInfos, maxSamples, SampleStateKind.Any,
                ViewStateKind.Any, InstanceStateKind.Any);
        }

        public ReturnCode Read(
            ref ContinueScale[] dataValues,
            ref SampleInfo[] sampleInfos,
            SampleStateKind sampleStates,
            ViewStateKind viewStates,
            InstanceStateKind instanceStates)
        {
            return Read(ref dataValues, ref sampleInfos, Length.Unlimited, sampleStates,
                viewStates, instanceStates);
        }

        public override ReturnCode Read(
                ref ContinueScale[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.Read(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode Take(
            ref ContinueScale[] dataValues,
            ref SampleInfo[] sampleInfos)
        {
            return Take(ref dataValues, ref sampleInfos, Length.Unlimited);
        }

        public ReturnCode Take(
            ref ContinueScale[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples)
        {
            return Take(ref dataValues, ref sampleInfos, maxSamples, SampleStateKind.Any,
                ViewStateKind.Any, InstanceStateKind.Any);
        }

        public ReturnCode Take(
            ref ContinueScale[] dataValues,
            ref SampleInfo[] sampleInfos,
            SampleStateKind sampleStates,
            ViewStateKind viewStates,
            InstanceStateKind instanceStates)
        {
            return Take(ref dataValues, ref sampleInfos, Length.Unlimited, sampleStates,
                viewStates, instanceStates);
        }

        public override ReturnCode Take(
                ref ContinueScale[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.Take(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode ReadWithCondition(
            ref ContinueScale[] dataValues,
            ref SampleInfo[] sampleInfos,
            IReadCondition readCondition)
        {
            return ReadWithCondition(ref dataValues, ref sampleInfos,
                Length.Unlimited, readCondition);
        }

        public override ReturnCode ReadWithCondition(
                ref ContinueScale[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.ReadWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        readCondition);
            return result;
        }

        public ReturnCode TakeWithCondition(
            ref ContinueScale[] dataValues,
            ref SampleInfo[] sampleInfos,
            IReadCondition readCondition)
        {
            return TakeWithCondition(ref dataValues, ref sampleInfos,
                Length.Unlimited, readCondition);
        }

        public override ReturnCode TakeWithCondition(
                ref ContinueScale[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.TakeWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        readCondition);
            return result;
        }

        public override ReturnCode ReadNextSample(
                ref ContinueScale dataValue,
                ref SampleInfo sampleInfo)
        {
            ReturnCode result =
                base.ReadNextSample(
                        ref dataValue,
                        ref sampleInfo);
            return result;
        }

        public override ReturnCode TakeNextSample(
                ref ContinueScale dataValue,
                ref SampleInfo sampleInfo)
        {
            ReturnCode result =
                base.TakeNextSample(
                        ref dataValue,
                        ref sampleInfo);
            return result;
        }

        public ReturnCode ReadInstance(
            ref ContinueScale[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return ReadInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode ReadInstance(
            ref ContinueScale[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return ReadInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode ReadInstance(
                ref ContinueScale[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.ReadInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode TakeInstance(
            ref ContinueScale[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return TakeInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode TakeInstance(
            ref ContinueScale[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return TakeInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode TakeInstance(
                ref ContinueScale[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.TakeInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode ReadNextInstance(
            ref ContinueScale[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return ReadNextInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode ReadNextInstance(
            ref ContinueScale[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return ReadNextInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode ReadNextInstance(
                ref ContinueScale[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.ReadNextInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode TakeNextInstance(
            ref ContinueScale[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return TakeNextInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode TakeNextInstance(
            ref ContinueScale[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return TakeNextInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode TakeNextInstance(
                ref ContinueScale[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.TakeNextInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode ReadNextInstanceWithCondition(
                ref ContinueScale[] dataValues,
                ref SampleInfo[] sampleInfos,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            return ReadNextInstanceWithCondition(
                ref dataValues,
                ref sampleInfos,
                Length.Unlimited,
                instanceHandle,
                readCondition);
        }

        public override ReturnCode ReadNextInstanceWithCondition(
                ref ContinueScale[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.ReadNextInstanceWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        readCondition);
            return result;
        }

        public ReturnCode TakeNextInstanceWithCondition(
                ref ContinueScale[] dataValues,
                ref SampleInfo[] sampleInfos,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            return TakeNextInstanceWithCondition(
                ref dataValues,
                ref sampleInfos,
                Length.Unlimited,
                instanceHandle,
                readCondition);
        }

        public override ReturnCode TakeNextInstanceWithCondition(
                ref ContinueScale[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.TakeNextInstanceWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        readCondition);

            return result;
        }

        public override ReturnCode ReturnLoan(
                ref ContinueScale[] dataValues,
                ref SampleInfo[] sampleInfos)
        {
            ReturnCode result =
                base.ReturnLoan(
                        ref dataValues,
                        ref sampleInfos);

            return result;
        }

        public override ReturnCode GetKeyValue(
                ref ContinueScale key,
                InstanceHandle handle)
        {
            ReturnCode result = base.GetKeyValue(
                        ref key,
                        handle);
            return result;
        }

        public override InstanceHandle LookupInstance(
                ContinueScale instance)
        {
            return
                base.LookupInstance(
                        instance);
        }

    }
    #endregion
    
    #region ContinueScaleDataWriter
    public class ContinueScaleDataWriter : DDS.OpenSplice.FooDataWriter<ContinueScale, ContinueScaleMarshaler>, 
                                         IContinueScaleDataWriter
    {
        public ContinueScaleDataWriter(DatabaseMarshaler marshaler)
            : base(marshaler) { }

        public InstanceHandle RegisterInstance(
                ContinueScale instanceData)
        {
            return base.RegisterInstance(
                    instanceData,
                    Time.Current);
        }

        public InstanceHandle RegisterInstanceWithTimestamp(
                ContinueScale instanceData,
                Time sourceTimestamp)
        {
            return base.RegisterInstance(
                    instanceData,
                    sourceTimestamp);
        }

        public ReturnCode UnregisterInstance(
                ContinueScale instanceData,
                InstanceHandle instanceHandle)
        {
            return base.UnregisterInstance(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode UnregisterInstanceWithTimestamp(
                ContinueScale instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.UnregisterInstance(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public ReturnCode Write(ContinueScale instanceData)
        {
            return base.Write(
                    instanceData,
                    InstanceHandle.Nil,
                    Time.Current);
        }

        public ReturnCode Write(
                ContinueScale instanceData,
                InstanceHandle instanceHandle)
        {
            return base.Write(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode WriteWithTimestamp(
                ContinueScale instanceData,
                Time sourceTimestamp)
        {
            return base.Write(
                    instanceData,
                    InstanceHandle.Nil,
                    sourceTimestamp);
        }

        public ReturnCode WriteWithTimestamp(
                ContinueScale instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.Write(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public ReturnCode Dispose(
                ContinueScale instanceData,
                InstanceHandle instanceHandle)
        {
            return base.Dispose(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode DisposeWithTimestamp(
                ContinueScale instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.Dispose(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public ReturnCode WriteDispose(
                ContinueScale instanceData)
        {
            return base.WriteDispose(
                    instanceData,
                    InstanceHandle.Nil,
                    Time.Current);
        }

        public ReturnCode WriteDispose(
                ContinueScale instanceData,
                InstanceHandle instanceHandle)
        {
            return base.WriteDispose(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode WriteDisposeWithTimestamp(
                ContinueScale instanceData,
                Time sourceTimestamp)
        {
            return base.WriteDispose(
                    instanceData,
                    InstanceHandle.Nil,
                    sourceTimestamp);
        }

        public ReturnCode WriteDisposeWithTimestamp(
                ContinueScale instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.WriteDispose(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public override ReturnCode GetKeyValue(
                ref ContinueScale key,
                InstanceHandle instanceHandle)
        {
            return base.GetKeyValue(ref key, instanceHandle);
        }

        public override InstanceHandle LookupInstance(
            ContinueScale instanceData)
        {
            return base.LookupInstance(instanceData);
        }
    }
    #endregion

    #region ContinueScaleTypeSupport
    public class ContinueScaleTypeSupport : DDS.OpenSplice.TypeSupport
    {
        private static readonly string[] metaDescriptor = {"<MetaData version=\"1.0.0\"><Module name=\"EDAQ\"><TypeDef name=\"scaledata\"><Sequence><Double/></Sequence>",
"</TypeDef><Struct name=\"ContinueScale\"><Member name=\"bbg_id\"><UShort/></Member><Member name=\"sensorName\">",
"<String/></Member><Member name=\"dateTime\"><String/></Member><Member name=\"check_count\"><UShort/></Member>",
"<Member name=\"read_count\"><ULong/></Member><Member name=\"sample_rate\"><Double/></Member><Member name=\"payload\">",
"<Type name=\"scaledata\"/></Member></Struct></Module></MetaData>"};

        public ContinueScaleTypeSupport()
            : base(typeof(ContinueScale), metaDescriptor, "EDAQ::ContinueScale", "", "bbg_id,sensorName")
        { }


        public override ReturnCode RegisterType(IDomainParticipant participant, string typeName)
        {
            return RegisterType(participant, typeName, new ContinueScaleMarshaler());
        }

        public override DDS.OpenSplice.DataWriter CreateDataWriter(DatabaseMarshaler marshaler)
        {
            return new ContinueScaleDataWriter(marshaler);
        }

        public override DDS.OpenSplice.DataReader CreateDataReader(DatabaseMarshaler marshaler)
        {
            return new ContinueScaleDataReader(marshaler);
        }
    }
    #endregion

    #region SensorDataDataReader
    public class SensorDataDataReader : DDS.OpenSplice.FooDataReader<SensorData, SensorDataMarshaler>, 
                                         ISensorDataDataReader
    {
        public SensorDataDataReader(DatabaseMarshaler marshaler)
            : base(marshaler) { }

        public ReturnCode Read(
            ref SensorData[] dataValues,
            ref SampleInfo[] sampleInfos)
        {
            return Read(ref dataValues, ref sampleInfos, Length.Unlimited);
        }

        public ReturnCode Read(
            ref SensorData[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples)
        {
            return Read(ref dataValues, ref sampleInfos, maxSamples, SampleStateKind.Any,
                ViewStateKind.Any, InstanceStateKind.Any);
        }

        public ReturnCode Read(
            ref SensorData[] dataValues,
            ref SampleInfo[] sampleInfos,
            SampleStateKind sampleStates,
            ViewStateKind viewStates,
            InstanceStateKind instanceStates)
        {
            return Read(ref dataValues, ref sampleInfos, Length.Unlimited, sampleStates,
                viewStates, instanceStates);
        }

        public override ReturnCode Read(
                ref SensorData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.Read(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode Take(
            ref SensorData[] dataValues,
            ref SampleInfo[] sampleInfos)
        {
            return Take(ref dataValues, ref sampleInfos, Length.Unlimited);
        }

        public ReturnCode Take(
            ref SensorData[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples)
        {
            return Take(ref dataValues, ref sampleInfos, maxSamples, SampleStateKind.Any,
                ViewStateKind.Any, InstanceStateKind.Any);
        }

        public ReturnCode Take(
            ref SensorData[] dataValues,
            ref SampleInfo[] sampleInfos,
            SampleStateKind sampleStates,
            ViewStateKind viewStates,
            InstanceStateKind instanceStates)
        {
            return Take(ref dataValues, ref sampleInfos, Length.Unlimited, sampleStates,
                viewStates, instanceStates);
        }

        public override ReturnCode Take(
                ref SensorData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.Take(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode ReadWithCondition(
            ref SensorData[] dataValues,
            ref SampleInfo[] sampleInfos,
            IReadCondition readCondition)
        {
            return ReadWithCondition(ref dataValues, ref sampleInfos,
                Length.Unlimited, readCondition);
        }

        public override ReturnCode ReadWithCondition(
                ref SensorData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.ReadWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        readCondition);
            return result;
        }

        public ReturnCode TakeWithCondition(
            ref SensorData[] dataValues,
            ref SampleInfo[] sampleInfos,
            IReadCondition readCondition)
        {
            return TakeWithCondition(ref dataValues, ref sampleInfos,
                Length.Unlimited, readCondition);
        }

        public override ReturnCode TakeWithCondition(
                ref SensorData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.TakeWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        readCondition);
            return result;
        }

        public override ReturnCode ReadNextSample(
                ref SensorData dataValue,
                ref SampleInfo sampleInfo)
        {
            ReturnCode result =
                base.ReadNextSample(
                        ref dataValue,
                        ref sampleInfo);
            return result;
        }

        public override ReturnCode TakeNextSample(
                ref SensorData dataValue,
                ref SampleInfo sampleInfo)
        {
            ReturnCode result =
                base.TakeNextSample(
                        ref dataValue,
                        ref sampleInfo);
            return result;
        }

        public ReturnCode ReadInstance(
            ref SensorData[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return ReadInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode ReadInstance(
            ref SensorData[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return ReadInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode ReadInstance(
                ref SensorData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.ReadInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode TakeInstance(
            ref SensorData[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return TakeInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode TakeInstance(
            ref SensorData[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return TakeInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode TakeInstance(
                ref SensorData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.TakeInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode ReadNextInstance(
            ref SensorData[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return ReadNextInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode ReadNextInstance(
            ref SensorData[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return ReadNextInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode ReadNextInstance(
                ref SensorData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.ReadNextInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode TakeNextInstance(
            ref SensorData[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return TakeNextInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode TakeNextInstance(
            ref SensorData[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return TakeNextInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode TakeNextInstance(
                ref SensorData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.TakeNextInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode ReadNextInstanceWithCondition(
                ref SensorData[] dataValues,
                ref SampleInfo[] sampleInfos,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            return ReadNextInstanceWithCondition(
                ref dataValues,
                ref sampleInfos,
                Length.Unlimited,
                instanceHandle,
                readCondition);
        }

        public override ReturnCode ReadNextInstanceWithCondition(
                ref SensorData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.ReadNextInstanceWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        readCondition);
            return result;
        }

        public ReturnCode TakeNextInstanceWithCondition(
                ref SensorData[] dataValues,
                ref SampleInfo[] sampleInfos,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            return TakeNextInstanceWithCondition(
                ref dataValues,
                ref sampleInfos,
                Length.Unlimited,
                instanceHandle,
                readCondition);
        }

        public override ReturnCode TakeNextInstanceWithCondition(
                ref SensorData[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.TakeNextInstanceWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        readCondition);

            return result;
        }

        public override ReturnCode ReturnLoan(
                ref SensorData[] dataValues,
                ref SampleInfo[] sampleInfos)
        {
            ReturnCode result =
                base.ReturnLoan(
                        ref dataValues,
                        ref sampleInfos);

            return result;
        }

        public override ReturnCode GetKeyValue(
                ref SensorData key,
                InstanceHandle handle)
        {
            ReturnCode result = base.GetKeyValue(
                        ref key,
                        handle);
            return result;
        }

        public override InstanceHandle LookupInstance(
                SensorData instance)
        {
            return
                base.LookupInstance(
                        instance);
        }

    }
    #endregion
    
    #region SensorDataDataWriter
    public class SensorDataDataWriter : DDS.OpenSplice.FooDataWriter<SensorData, SensorDataMarshaler>, 
                                         ISensorDataDataWriter
    {
        public SensorDataDataWriter(DatabaseMarshaler marshaler)
            : base(marshaler) { }

        public InstanceHandle RegisterInstance(
                SensorData instanceData)
        {
            return base.RegisterInstance(
                    instanceData,
                    Time.Current);
        }

        public InstanceHandle RegisterInstanceWithTimestamp(
                SensorData instanceData,
                Time sourceTimestamp)
        {
            return base.RegisterInstance(
                    instanceData,
                    sourceTimestamp);
        }

        public ReturnCode UnregisterInstance(
                SensorData instanceData,
                InstanceHandle instanceHandle)
        {
            return base.UnregisterInstance(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode UnregisterInstanceWithTimestamp(
                SensorData instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.UnregisterInstance(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public ReturnCode Write(SensorData instanceData)
        {
            return base.Write(
                    instanceData,
                    InstanceHandle.Nil,
                    Time.Current);
        }

        public ReturnCode Write(
                SensorData instanceData,
                InstanceHandle instanceHandle)
        {
            return base.Write(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode WriteWithTimestamp(
                SensorData instanceData,
                Time sourceTimestamp)
        {
            return base.Write(
                    instanceData,
                    InstanceHandle.Nil,
                    sourceTimestamp);
        }

        public ReturnCode WriteWithTimestamp(
                SensorData instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.Write(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public ReturnCode Dispose(
                SensorData instanceData,
                InstanceHandle instanceHandle)
        {
            return base.Dispose(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode DisposeWithTimestamp(
                SensorData instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.Dispose(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public ReturnCode WriteDispose(
                SensorData instanceData)
        {
            return base.WriteDispose(
                    instanceData,
                    InstanceHandle.Nil,
                    Time.Current);
        }

        public ReturnCode WriteDispose(
                SensorData instanceData,
                InstanceHandle instanceHandle)
        {
            return base.WriteDispose(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode WriteDisposeWithTimestamp(
                SensorData instanceData,
                Time sourceTimestamp)
        {
            return base.WriteDispose(
                    instanceData,
                    InstanceHandle.Nil,
                    sourceTimestamp);
        }

        public ReturnCode WriteDisposeWithTimestamp(
                SensorData instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.WriteDispose(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public override ReturnCode GetKeyValue(
                ref SensorData key,
                InstanceHandle instanceHandle)
        {
            return base.GetKeyValue(ref key, instanceHandle);
        }

        public override InstanceHandle LookupInstance(
            SensorData instanceData)
        {
            return base.LookupInstance(instanceData);
        }
    }
    #endregion

    #region SensorDataTypeSupport
    public class SensorDataTypeSupport : DDS.OpenSplice.TypeSupport
    {
        private static readonly string[] metaDescriptor = {"<MetaData version=\"1.0.0\"><Module name=\"EDAQ\"><Struct name=\"SensorData\"><Member name=\"bbg_id\">",
"<UShort/></Member><Member name=\"sensorName\"><String/></Member><Member name=\"dateTime\"><String/></Member>",
"<Member name=\"value\"><Double/></Member></Struct></Module></MetaData>"};

        public SensorDataTypeSupport()
            : base(typeof(SensorData), metaDescriptor, "EDAQ::SensorData", "", "bbg_id,sensorName")
        { }


        public override ReturnCode RegisterType(IDomainParticipant participant, string typeName)
        {
            return RegisterType(participant, typeName, new SensorDataMarshaler());
        }

        public override DDS.OpenSplice.DataWriter CreateDataWriter(DatabaseMarshaler marshaler)
        {
            return new SensorDataDataWriter(marshaler);
        }

        public override DDS.OpenSplice.DataReader CreateDataReader(DatabaseMarshaler marshaler)
        {
            return new SensorDataDataReader(marshaler);
        }
    }
    #endregion

}

namespace HB
{
    #region NetworkingDataReader
    public class NetworkingDataReader : DDS.OpenSplice.FooDataReader<Networking, NetworkingMarshaler>, 
                                         INetworkingDataReader
    {
        public NetworkingDataReader(DatabaseMarshaler marshaler)
            : base(marshaler) { }

        public ReturnCode Read(
            ref Networking[] dataValues,
            ref SampleInfo[] sampleInfos)
        {
            return Read(ref dataValues, ref sampleInfos, Length.Unlimited);
        }

        public ReturnCode Read(
            ref Networking[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples)
        {
            return Read(ref dataValues, ref sampleInfos, maxSamples, SampleStateKind.Any,
                ViewStateKind.Any, InstanceStateKind.Any);
        }

        public ReturnCode Read(
            ref Networking[] dataValues,
            ref SampleInfo[] sampleInfos,
            SampleStateKind sampleStates,
            ViewStateKind viewStates,
            InstanceStateKind instanceStates)
        {
            return Read(ref dataValues, ref sampleInfos, Length.Unlimited, sampleStates,
                viewStates, instanceStates);
        }

        public override ReturnCode Read(
                ref Networking[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.Read(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode Take(
            ref Networking[] dataValues,
            ref SampleInfo[] sampleInfos)
        {
            return Take(ref dataValues, ref sampleInfos, Length.Unlimited);
        }

        public ReturnCode Take(
            ref Networking[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples)
        {
            return Take(ref dataValues, ref sampleInfos, maxSamples, SampleStateKind.Any,
                ViewStateKind.Any, InstanceStateKind.Any);
        }

        public ReturnCode Take(
            ref Networking[] dataValues,
            ref SampleInfo[] sampleInfos,
            SampleStateKind sampleStates,
            ViewStateKind viewStates,
            InstanceStateKind instanceStates)
        {
            return Take(ref dataValues, ref sampleInfos, Length.Unlimited, sampleStates,
                viewStates, instanceStates);
        }

        public override ReturnCode Take(
                ref Networking[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.Take(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode ReadWithCondition(
            ref Networking[] dataValues,
            ref SampleInfo[] sampleInfos,
            IReadCondition readCondition)
        {
            return ReadWithCondition(ref dataValues, ref sampleInfos,
                Length.Unlimited, readCondition);
        }

        public override ReturnCode ReadWithCondition(
                ref Networking[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.ReadWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        readCondition);
            return result;
        }

        public ReturnCode TakeWithCondition(
            ref Networking[] dataValues,
            ref SampleInfo[] sampleInfos,
            IReadCondition readCondition)
        {
            return TakeWithCondition(ref dataValues, ref sampleInfos,
                Length.Unlimited, readCondition);
        }

        public override ReturnCode TakeWithCondition(
                ref Networking[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.TakeWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        readCondition);
            return result;
        }

        public override ReturnCode ReadNextSample(
                ref Networking dataValue,
                ref SampleInfo sampleInfo)
        {
            ReturnCode result =
                base.ReadNextSample(
                        ref dataValue,
                        ref sampleInfo);
            return result;
        }

        public override ReturnCode TakeNextSample(
                ref Networking dataValue,
                ref SampleInfo sampleInfo)
        {
            ReturnCode result =
                base.TakeNextSample(
                        ref dataValue,
                        ref sampleInfo);
            return result;
        }

        public ReturnCode ReadInstance(
            ref Networking[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return ReadInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode ReadInstance(
            ref Networking[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return ReadInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode ReadInstance(
                ref Networking[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.ReadInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode TakeInstance(
            ref Networking[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return TakeInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode TakeInstance(
            ref Networking[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return TakeInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode TakeInstance(
                ref Networking[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.TakeInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode ReadNextInstance(
            ref Networking[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return ReadNextInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode ReadNextInstance(
            ref Networking[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return ReadNextInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode ReadNextInstance(
                ref Networking[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.ReadNextInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode TakeNextInstance(
            ref Networking[] dataValues,
            ref SampleInfo[] sampleInfos,
            InstanceHandle instanceHandle)
        {
            return TakeNextInstance(ref dataValues, ref sampleInfos, Length.Unlimited, instanceHandle);
        }

        public ReturnCode TakeNextInstance(
            ref Networking[] dataValues,
            ref SampleInfo[] sampleInfos,
            int maxSamples,
            InstanceHandle instanceHandle)
        {
            return TakeNextInstance(ref dataValues, ref sampleInfos, maxSamples, instanceHandle,
                SampleStateKind.Any, ViewStateKind.Any, InstanceStateKind.Any);
        }

        public override ReturnCode TakeNextInstance(
                ref Networking[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                SampleStateKind sampleStates,
                ViewStateKind viewStates,
                InstanceStateKind instanceStates)
        {
            ReturnCode result =
                base.TakeNextInstance(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        sampleStates,
                        viewStates,
                        instanceStates);
            return result;
        }

        public ReturnCode ReadNextInstanceWithCondition(
                ref Networking[] dataValues,
                ref SampleInfo[] sampleInfos,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            return ReadNextInstanceWithCondition(
                ref dataValues,
                ref sampleInfos,
                Length.Unlimited,
                instanceHandle,
                readCondition);
        }

        public override ReturnCode ReadNextInstanceWithCondition(
                ref Networking[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.ReadNextInstanceWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        readCondition);
            return result;
        }

        public ReturnCode TakeNextInstanceWithCondition(
                ref Networking[] dataValues,
                ref SampleInfo[] sampleInfos,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            return TakeNextInstanceWithCondition(
                ref dataValues,
                ref sampleInfos,
                Length.Unlimited,
                instanceHandle,
                readCondition);
        }

        public override ReturnCode TakeNextInstanceWithCondition(
                ref Networking[] dataValues,
                ref SampleInfo[] sampleInfos,
                int maxSamples,
                InstanceHandle instanceHandle,
                IReadCondition readCondition)
        {
            ReturnCode result =
                base.TakeNextInstanceWithCondition(
                        ref dataValues,
                        ref sampleInfos,
                        maxSamples,
                        instanceHandle,
                        readCondition);

            return result;
        }

        public override ReturnCode ReturnLoan(
                ref Networking[] dataValues,
                ref SampleInfo[] sampleInfos)
        {
            ReturnCode result =
                base.ReturnLoan(
                        ref dataValues,
                        ref sampleInfos);

            return result;
        }

        public override ReturnCode GetKeyValue(
                ref Networking key,
                InstanceHandle handle)
        {
            ReturnCode result = base.GetKeyValue(
                        ref key,
                        handle);
            return result;
        }

        public override InstanceHandle LookupInstance(
                Networking instance)
        {
            return
                base.LookupInstance(
                        instance);
        }

    }
    #endregion
    
    #region NetworkingDataWriter
    public class NetworkingDataWriter : DDS.OpenSplice.FooDataWriter<Networking, NetworkingMarshaler>, 
                                         INetworkingDataWriter
    {
        public NetworkingDataWriter(DatabaseMarshaler marshaler)
            : base(marshaler) { }

        public InstanceHandle RegisterInstance(
                Networking instanceData)
        {
            return base.RegisterInstance(
                    instanceData,
                    Time.Current);
        }

        public InstanceHandle RegisterInstanceWithTimestamp(
                Networking instanceData,
                Time sourceTimestamp)
        {
            return base.RegisterInstance(
                    instanceData,
                    sourceTimestamp);
        }

        public ReturnCode UnregisterInstance(
                Networking instanceData,
                InstanceHandle instanceHandle)
        {
            return base.UnregisterInstance(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode UnregisterInstanceWithTimestamp(
                Networking instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.UnregisterInstance(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public ReturnCode Write(Networking instanceData)
        {
            return base.Write(
                    instanceData,
                    InstanceHandle.Nil,
                    Time.Current);
        }

        public ReturnCode Write(
                Networking instanceData,
                InstanceHandle instanceHandle)
        {
            return base.Write(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode WriteWithTimestamp(
                Networking instanceData,
                Time sourceTimestamp)
        {
            return base.Write(
                    instanceData,
                    InstanceHandle.Nil,
                    sourceTimestamp);
        }

        public ReturnCode WriteWithTimestamp(
                Networking instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.Write(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public ReturnCode Dispose(
                Networking instanceData,
                InstanceHandle instanceHandle)
        {
            return base.Dispose(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode DisposeWithTimestamp(
                Networking instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.Dispose(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public ReturnCode WriteDispose(
                Networking instanceData)
        {
            return base.WriteDispose(
                    instanceData,
                    InstanceHandle.Nil,
                    Time.Current);
        }

        public ReturnCode WriteDispose(
                Networking instanceData,
                InstanceHandle instanceHandle)
        {
            return base.WriteDispose(
                    instanceData,
                    instanceHandle,
                    Time.Current);
        }

        public ReturnCode WriteDisposeWithTimestamp(
                Networking instanceData,
                Time sourceTimestamp)
        {
            return base.WriteDispose(
                    instanceData,
                    InstanceHandle.Nil,
                    sourceTimestamp);
        }

        public ReturnCode WriteDisposeWithTimestamp(
                Networking instanceData,
                InstanceHandle instanceHandle,
                Time sourceTimestamp)
        {
            return base.WriteDispose(
                    instanceData,
                    instanceHandle,
                    sourceTimestamp);
        }

        public override ReturnCode GetKeyValue(
                ref Networking key,
                InstanceHandle instanceHandle)
        {
            return base.GetKeyValue(ref key, instanceHandle);
        }

        public override InstanceHandle LookupInstance(
            Networking instanceData)
        {
            return base.LookupInstance(instanceData);
        }
    }
    #endregion

    #region NetworkingTypeSupport
    public class NetworkingTypeSupport : DDS.OpenSplice.TypeSupport
    {
        private static readonly string[] metaDescriptor = {"<MetaData version=\"1.0.0\"><Module name=\"HB\"><Struct name=\"Networking\"><Member name=\"bbg_id\"><UShort/>",
"</Member><Member name=\"ipv4\"><String/></Member><Member name=\"mac\"><String/></Member></Struct></Module>",
"</MetaData>"};

        public NetworkingTypeSupport()
            : base(typeof(Networking), metaDescriptor, "HB::Networking", "", "bbg_id")
        { }


        public override ReturnCode RegisterType(IDomainParticipant participant, string typeName)
        {
            return RegisterType(participant, typeName, new NetworkingMarshaler());
        }

        public override DDS.OpenSplice.DataWriter CreateDataWriter(DatabaseMarshaler marshaler)
        {
            return new NetworkingDataWriter(marshaler);
        }

        public override DDS.OpenSplice.DataReader CreateDataReader(DatabaseMarshaler marshaler)
        {
            return new NetworkingDataReader(marshaler);
        }
    }
    #endregion

}

