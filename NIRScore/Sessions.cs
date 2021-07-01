using System;
using System.Collections.Generic;

namespace NIRScore
{
  public class Sessions
  {
    public readonly List<Session> sessions;

    public double trueTiso;
    public double effectiveTiso;

    public Sessions()
    {
      sessions = new List<Session>();
    }

    private bool ExistFile(string fileName)
    {
      foreach (Session session in sessions)
      {
        if (session.filePath == fileName)
        {
          return true;
        }
      }
      return false;
    }

    public bool AddSession(string fileName)
    {
      if (ExistFile(fileName))
      {
        return false;
      }
      Session session = new Session(fileName);
      sessions.Add(session);
      return true;
    }

    public bool AddSession(Session session)
    {
      if (ExistFile(session.filePath))
      {
        return false;
      }
      sessions.Add(session);
      return true;
    }

    public Session GetLastSession()
    {
      if (sessions.Count > 0)
      {
        return sessions[sessions.Count - 1];
      }
      return null;
    }

    public void ParseAllEvents()
    {
      foreach (Session session in sessions)
      {
        session.ParseEvents();
      }
    }

    public void ReReadFiles()
    {
      foreach (Session session in sessions)
      {
        session.ReadFile();
      }
    }

    public void ComputeTiso()
    {
#if DEBUG
      Console.Write("[ComputeTiso]");
#endif
      trueTiso = -1;
      foreach (Session session in sessions)
      {
        if (!session.IsValidFile)
        {
          continue;
        }

        if (trueTiso < 0 || trueTiso > session.Tlim)
        {
          trueTiso = session.TlimEff;
        }
      }

#if DEBUG
      Console.Write(" " + Convert.ToString(trueTiso));
#endif

      effectiveTiso = trueTiso;
      foreach (Session session in sessions)
      {
        double tmp = session.TimeBeforeOcclusion(trueTiso);
        if (tmp < effectiveTiso)
        {
          effectiveTiso = tmp;
        }
      }

#if DEBUG
      Console.WriteLine(" " + Convert.ToString(effectiveTiso));
#endif
    }

    public void ComputeAnalysis()
    {
      foreach (Session session in sessions)
      {
        if (!session.IsValidFile)
        {
          continue;
        }

        session.ComputeBaseline();
        session.ComputeLim();
        session.ComputeIso(effectiveTiso);
        if (session.HasOcclusions && session.baselineOcclusion != null)
        {
          session.ComputeSlopeLim();
          session.ComputeSlopeIso(effectiveTiso);
        }
#if DEBUG
        Console.Write("[ComputeAnalysis] ");
        Console.Write(session.HasOcclusions);
        Console.Write(" ");
        Console.WriteLine(session.baselineOcclusion == null);
#endif
      }
    }

    public void Compute()
    {
      ComputeTiso();
      ComputeAnalysis();
    }

  }
}
